﻿using Authentication.Context;
using Authentication.Model;
using Authentication.Security;
using Resenha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Resenha.Util;
namespace Resenha.BO
{
    public class AuthenticationBO
    {

        public ReturnJson Register(User pUser,
                                   TokenConfiguration pTokenConfigurations,
                                   SigningConfigurations pSigningConfigurations,
                                   CadastroContext context)
        {

            ReturnJson returnJson = new ReturnJson();
            UserLogin user = new UserLogin();
            int credentialsAccept = 1;

            Token geraToken = new Token(pTokenConfigurations, pSigningConfigurations);

            try
            {
                //campos obrigatorios
                if (pUser == null)
                {
                    credentialsAccept = 0;
                }
                //informações invalidas
                else if (string.IsNullOrEmpty(pUser.firstName) ||
                        string.IsNullOrEmpty(pUser.lastName) ||
                        string.IsNullOrEmpty(pUser.email))
                {
                    credentialsAccept = 0;
                }

                //senhas inválidass
                else if (!ContainsLetterLower(pUser.userLogin.password) &&
                         !ContainsLetterUpper(pUser.userLogin.password) &&
                         !ContainsNumber(pUser.userLogin.password) &&
                         pUser.userLogin.password.Length < 6)
                    credentialsAccept = 2;

                //senhas diferentes
                else if (!pUser.userLogin.password.Equals(pUser.userLogin.confirmPassword))
                    credentialsAccept = 2;


                ////usuário existente
                else if (context.User.Any(p => p.email.Equals(pUser.email) &&
                                              p.userLogin.originAccess == pUser.userLogin.originAccess)
                                              )
                {
                    credentialsAccept = 5;
                }

                switch (credentialsAccept)
                {
                    case 0:

                        returnJson.statusProcess = Enumerator.StatusProcess.Invalid_Credentials;
                        returnJson.message = "Preencha os campos obrigatórios";
                        break;
                    case 1:
                        returnJson.bodyToken = new BodyToken();
                        returnJson.bodyToken = geraToken.GeraToken(pUser, pTokenConfigurations);
                        returnJson.message = "Usuário cadastrado com sucesso";
                        pUser.dtRegister = DateTime.Now;

                        pUser.userLogin.userName = string.Concat(pUser.firstName, ".", pUser.lastName);

                        context.UserLogin.Add(pUser.userLogin);
                        context.User.Add(pUser);
                        context.SaveChanges();

                        returnJson.data.Add(pUser);

                        break;

                    case 2:

                        returnJson.statusProcess = Enumerator.StatusProcess.Invalid_Credentials;
                        returnJson.message = "Informações inválidas, senha não atende aos critérios desejados. Senha deve conter números, letras minúsculas e letras maíusculas.";
                        break;

                    case 3:

                        returnJson.statusProcess = Enumerator.StatusProcess.Invalid_Credentials;
                        returnJson.message = "Senha e confirmação de senha estão diferentes";
                        break;
                    case 5:

                        returnJson.statusProcess = Enumerator.StatusProcess.Invalid_Credentials;
                        returnJson.message = "Existe um cadastro com este e-mail.";
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnJson;
        }



        public ReturnJson Login(User pUser, CadastroContext context)
        {
            ReturnJson returnJson = new ReturnJson();
            try
            {
                User findUser;

                switch (pUser.userLogin.originAccess)
                {
                    case (int)Enumerator.OriginAccess.APPLICATION:

                        if(string.IsNullOrWhiteSpace(pUser.email))
                        {
                            returnJson.message = "E-mail obrigatório";
                            returnJson.statusProcess = Enumerator.StatusProcess.Invalid_Credentials;

                        }


                        if (!context.User.Any(p =>  p.email == pUser.email))
                        {
                            returnJson.message = "E-mail não encontrado";
                            returnJson.statusProcess = Enumerator.StatusProcess.Invalid_Credentials;
                        }

                        findUser = context.User.Where(p => p.email == pUser.email).FirstOrDefault();

                         if (!context.UserLogin.Any(p => p.userLoginId == findUser.userLoginId &&
                                                         p.password == pUser.userLogin.password))
                        {
                            returnJson.message = "E-mail e/ou senha inválidos";
                            returnJson.statusProcess = Enumerator.StatusProcess.Invalid_Credentials;
                        }
                        else
                        {
                            findUser.userLogin = context.UserLogin.Where(p => p.userLoginId == findUser.userLoginId &&
                                                                              p.password == pUser.userLogin.password).FirstOrDefault();
                        }



                        break;
                    case (int)Enumerator.OriginAccess.FACEBOOK:
                        break;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


            return returnJson;
        }


        #region Private Method's
        public bool ContainsLetterLower(string text)
        {
            if (text.Where(c => char.IsLower(c)).Count() > 0)
                return true;
            else
                return false;
        }


        public bool ContainsLetterUpper(string text)
        {
            if (text.Where(c => char.IsUpper(c)).Count() > 0)
                return true;
            else
                return false;
        }

        public bool ContainsNumber(string text)
        {
            if (text.Where(c => char.IsNumber(c)).Count() > 0)
                return true;
            else
                return false;
        }
        #endregion
    }
}
