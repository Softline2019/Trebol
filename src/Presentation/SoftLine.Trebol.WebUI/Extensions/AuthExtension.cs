using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SoftLine.Trebol.Application.Features.Auths.Users.Vms;
using System.Security.Claims;

namespace SoftLine.Trebol.WebUI
{
    public class AuthExtension : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorage;
        private ClaimsPrincipal _sinInformacion = new ClaimsPrincipal(new ClaimsIdentity());

        public AuthExtension(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public async Task ActualizarEstadoAutenticacion(Session? sesionUsuario)
        {
            ClaimsPrincipal claimsPrincipal;

            if(sesionUsuario != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name,sesionUsuario.userName),
                    new Claim(ClaimTypes.Email,sesionUsuario.email),
                    new Claim(ClaimTypes.Role,sesionUsuario.Roles.First())
                },"JwtAuth"));

                await _sessionStorage.GuardarStorage("sesionUsuario", sesionUsuario);
            }
            else
            {
                claimsPrincipal = _sinInformacion;
                await _sessionStorage.RemoveItemAsync("sesionUsuario");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));

        }


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var sesionUsuario = await _sessionStorage.ObtenerStorage<Session>("sesionUsuario");

            if (sesionUsuario == null)
                return await Task.FromResult(new AuthenticationState(_sinInformacion));

            var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name,sesionUsuario.userName),
                    new Claim(ClaimTypes.Email,sesionUsuario.email),
                    new Claim(ClaimTypes.Role,sesionUsuario.Roles.First())
                }, "JwtAuth"));


            return await Task.FromResult(new AuthenticationState(claimPrincipal));

        }
    }
}
