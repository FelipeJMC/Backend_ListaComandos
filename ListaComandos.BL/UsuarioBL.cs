using AutoMapper;
using ListaComandos.BL.Common;
using ListaComandos.BL.Model;
using ListaComandos.BL.Response;
using ListaComandos.DAL;
using ListaComandos.DAL.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ListaComandos.BL
{
    public class UsuarioBL
    {
        public UsuarioDAL _dal;
        private Mapper _mapper;
        private readonly AppSettings _appSettings;


        public UsuarioBL(IOptions<AppSettings> appSettings)
        {
            _dal = new UsuarioDAL();
            var _config = new MapperConfiguration(cgf => cgf.CreateMap<TbUsuario, UsuarioModel>()
                             .ReverseMap());

            _mapper = new Mapper(_config);

            _appSettings = appSettings.Value;


        }
        public UsuarioResponse Login(UsuarioModel model)
        {

            UsuarioResponse res = new UsuarioResponse();

            TbUsuario usuario = _dal.ListarTodo()
                                    .Where(t => t.Usuario == model.Usuario).SingleOrDefault();

            model.Password = Tools.Tools.GetSHA256(model.Password);

            var login = _dal.Login(model.Usuario, model.Password);


            if (login == null) return null;

            res.Email = usuario.Email;
            res.Token = GetToken(usuario);


            return res;
        }

        private string GetToken(TbUsuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email)

                }
                ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave),
                                                                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


    }
}
