using System;
using System.Configuration;
using System.Data;
using CSAT.DAL.Helpers;
using CSAT.DTO;

using static CSAT.DAL.Helpers.DBHelpers;

namespace CSAT.DAL
{
    public class TokenDAL : ITokenDAL
    {
        #region Private member variables.
        private readonly DBHelpers _oDBHelper;
        private Parameters[] colParameters = null;

        #endregion
        #region Public constructor.
        /// <summary>
        /// Public constructor.
        /// </summary>
        public TokenDAL(DBHelpers oDBHelpers)
        {
            _oDBHelper = oDBHelpers;
        }
        #endregion

        /// <summary>
        ///  Function to generate unique token with expiry against the provided userId.
        ///  Also add a record in database for generated token.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public TokenDTO GenerateToken(int userId)
        {
            
            string token = Guid.NewGuid().ToString();
            try
            {
                DateTime issuedOn = DateTime.Now;
                DateTime expiredOn = DateTime.Now.AddSeconds(
                                                  Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
                string paramPrefix = _oDBHelper.SetPrefixParam();

                colParameters = new Parameters[]
                                    {
                                        new  Parameters( paramPrefix+"UserId",   userId ),
                                        new  Parameters( paramPrefix+"AuthToken",  token ),
                                        new  Parameters( paramPrefix+"IssuedOn",  issuedOn ),
                                        new  Parameters( paramPrefix+"ExpiresOn",  expiredOn )
                                    };

                _oDBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "usp_GenerateToken", colParameters);
                var tokenModel = new TokenDTO()
                {
                    CsatUserId = userId,
                    IssuedOn = issuedOn,
                    ExpiresOn = expiredOn,
                    AuthToken = token
                };
                

                return tokenModel;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                colParameters = null;
            }
        }


        /// <summary>
        /// Method to validate token against expiry and existence in database.
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public bool ValidateToken(string tokenId)
        {
            
            try
            {
                string paramPrefix = _oDBHelper.SetPrefixParam();

                var token = CheckValidateToken(tokenId);
                if (token != null && !(DateTime.Now > token.ExpiresOn))
                {
                    token.ExpiresOn = token.ExpiresOn.AddSeconds(
                                                  Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
                    colParameters = new Parameters[]
                                    {
                                        new  Parameters( paramPrefix+"TokenId",   token.TokenId ),
                                        new  Parameters( paramPrefix+"ExpiresOn",  token.ExpiresOn )
                                    };

                    _oDBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "usp_UpdateToken", colParameters);

                    return true;
                }
               

                return false;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                colParameters = null;
            }

        }

        public bool Kill(string tokenId)
        {
           
            try
            {
                var bResult = DeleteTokenById(tokenId, 'T');
               
                return bResult;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        public bool DeleteByUserId(int userId)
        {
           
            try
            {
                var bResult = DeleteTokenById(Convert.ToString(userId), 'U');
               
                return bResult;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Public method to authenticate user by user name and password.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Authenticate(string userName, string password)
        {
            

            var userDTO = new CsatUserDTO();
            try
            {
                string paramPrefix = _oDBHelper.SetPrefixParam();
                colParameters = new Parameters[]
                                    {
                                        new  Parameters( paramPrefix+"LoginName",  userName ),
                                        new  Parameters( paramPrefix+"password",  password )
                                    };
                var reader = _oDBHelper.ExecuteReader(CommandType.StoredProcedure, "usp_Login", colParameters);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userDTO.CsatUserID = (int)reader["CsatUserID"];
                        userDTO.FirstName = (string)reader["FirstName"];
                    }
                }
                if (userDTO != null && userDTO.CsatUserID > 0)
                {
                    return userDTO.CsatUserID;
                }
                
                return 0;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                colParameters = null;
            }
        }

        private TokenDTO CheckValidateToken(string tokenId)
        {
            

            var tokenDTO = new TokenDTO();
            try
            {
                string paramPrefix = _oDBHelper.SetPrefixParam();
                colParameters = new Parameters[]
                                    {
                                        new  Parameters( paramPrefix+"Tokenid",  tokenId )
                                    };
                var reader = _oDBHelper.ExecuteReader(CommandType.StoredProcedure, "usp_ValidateToken", colParameters);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tokenDTO.TokenId = (int)reader["TokenId"];
                        tokenDTO.CsatUserId = (int)reader["CsatUserId"];
                        tokenDTO.AuthToken = (string)reader["AuthToken"];
                        tokenDTO.IssuedOn = (DateTime)reader["IssuedOn"];
                        tokenDTO.ExpiresOn = (DateTime)reader["ExpiresOn"];
                    }
                }

                
                return tokenDTO;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                colParameters = null;
            }
        }

        private bool DeleteTokenById(string Id, Char Flag)
        {

            
            string token = Guid.NewGuid().ToString();
            try
            {
                string paramPrefix = _oDBHelper.SetPrefixParam();

                colParameters = new Parameters[]
                                    {
                                        new  Parameters( paramPrefix+"Id",   Id ),
                                        new  Parameters( paramPrefix+"Flag",  Flag )
                                    };

                _oDBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "usp_DeleteTokenById", colParameters);

                

                return true;
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
            finally
            {
                colParameters = null;
            }
        }
    }
}
