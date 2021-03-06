﻿using System;
using System.Collections.Generic;
using Authentication.Context;
using Authentication.Model;
using Authentication.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resenha.BO;
using Resenha.Model;
using Resenha.Util;


//TESTE

namespace Authentication.Controllers
{
    [Produces("application/json")]
    [Route("api/Authentication")]
    public class AuthenticationController : Controller
    {

        private readonly CadastroContext _context;
        ReturnJson returnJson;

        public AuthenticationController(CadastroContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public ReturnJson Register([FromBody] User pRegister,
                                   [FromServices]TokenConfiguration pTokenConfigurations,
                                   [FromServices]SigningConfigurations pSigningConfigurations)
        {

            try
            {
                AuthenticationBO authentBO = new AuthenticationBO();
                returnJson = authentBO.Register(pRegister, pTokenConfigurations, pSigningConfigurations, _context);
            }
            catch (Exception ex)
            {
                returnJson.statusProcess = Enumerator.StatusProcess.Error_Application;
                returnJson.message = "Erro ao cadastrar/registrar cliente. Erro: " + ex.Message;
            }

            return returnJson;

        }

        [Route("Login")]
        [Authorize("Bearer")]
        public ReturnJson Login([FromBody] User pLogin)
        {
            try
            {
                AuthenticationBO authentBO = new AuthenticationBO();
                returnJson = authentBO.Login(pLogin, _context);

            }
            catch (Exception ex)
            {
                returnJson.statusProcess = Enumerator.StatusProcess.Error_Application;
                returnJson.message = "Erro ao cadastrar/registrar cliente. Erro: " + ex.Message;
            }
            return returnJson;
        }

    }
}