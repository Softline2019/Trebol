// Importa los espacios de nombres necesarios
using AutoMapper; // Para usar el mapeo de objetos
using MediatR; // Para usar el patrón Mediator
using Microsoft.AspNetCore.Identity; // Para usar la gestión de identidades de ASP.NET Core
using SoftLine.Trebol.Application.Contracts.Identity; // Para usar contratos de servicios de autenticación
using SoftLine.Trebol.Application.Exceptions; // Para usar excepciones personalizadas de la aplicación
using SoftLine.Trebol.Application.Features.Addresses.Vms; // Para usar View Models relacionados con direcciones
using SoftLine.Trebol.Application.Features.Auths.Users.Vms; // Para usar View Models relacionados con autenticación de usuarios
using SoftLine.Trebol.Application.Persistence; // Para usar la persistencia en la aplicación
using SoftLine.Trebol.Domain; // Para usar las entidades del dominio

namespace SoftLine.Trebol.Application.Features.Auths.Users.Commands.LoginUser
{
    // Implementa un manejador de comando para LoginUserCommand que retorna un AuthResponse
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResponse>
    {
        // Define campos privados para las dependencias necesarias
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        // Constructor para inicializar las dependencias
        public LoginUserCommandHandler(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager,
            IAuthService authService,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager; // Inicializa el campo _userManager con el parámetro userManager
            _signInManager = signInManager; // Inicializa el campo _signInManager con el parámetro signInManager
            _roleManager = roleManager; // Inicializa el campo _roleManager con el parámetro roleManager
            _authService = authService; // Inicializa el campo _authService con el parámetro authService
            _mapper = mapper; // Inicializa el campo _mapper con el parámetro mapper
            _unitOfWork = unitOfWork; // Inicializa el campo _unitOfWork con el parámetro unitOfWork
        }

        // Método Handle para procesar el comando LoginUserCommand
        public async Task<AuthResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Busca el usuario por email
            var user = await _userManager.FindByEmailAsync(request.Email!);
            if (user is null)
            {
                // Lanza una excepción si no se encuentra el usuario
                throw new NotFoundException(nameof(User), request.Email!);
            }

            // Verifica si el usuario está activo
            if (!user.IsActive)
            {
                // Lanza una excepción si el usuario está bloqueado
                throw new Exception($"El usuario está bloqueado, contacte al administrador");
            }

            // Verifica la contraseña del usuario
            var resultado = await _signInManager.CheckPasswordSignInAsync(user, request.Password!, false);
            if (!resultado.Succeeded)
            {
                // Lanza una excepción si la contraseña es incorrecta
                throw new Exception("Las credenciales del usuario son incorrectas");
            }

            // Opcional: obtiene la dirección de envío del usuario (comentado en el código original)
            // var direccionEnvio = await _unitOfWork.Repository<Address>().GetEntityAsync(x => x.UserName == user.UserName);

            // Obtiene los roles del usuario
            var roles = await _userManager.GetRolesAsync(user);

            // Crea una respuesta de autenticación con los datos del usuario y su token
            var authResponse = new AuthResponse
            {
                Id = user.Id, // Asigna el ID del usuario
                FirstName = user.FirstName, // Asigna el primer nombre del usuario
                LastName = user.LastName, // Asigna el apellido del usuario
                Phone = user.Phone, // Asigna el teléfono del usuario
                Email = user.Email, // Asigna el email del usuario
                UserName = user.UserName, // Asigna el nombre de usuario
                Avatar = user.AvatarUrl, // Asigna la URL del avatar del usuario
                Token = _authService.CreateToken(user, roles), // Genera un token de autenticación
                Roles = roles // Asigna los roles del usuario
            };

            // Devuelve la respuesta de autenticación
            return authResponse;
        }
    }
}
