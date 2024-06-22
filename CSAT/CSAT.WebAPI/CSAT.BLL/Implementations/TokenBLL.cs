using CSAT.BLL;
using CSAT.DAL;
using CSAT.DTO;

using System;
using System.Linq;

namespace CSAT.BLL
{
    public class TokenBLL : ITokenBLL
    {
        #region Private member variables.
        private readonly TokenDAL _tokenDAL;
        #endregion

        #region Public constructor.
        /// <summary>
        /// Public constructor.
        /// </summary>
        public TokenBLL(TokenDAL tokenDAL)
        {
            _tokenDAL = tokenDAL;
        }
        #endregion
        #region Public member methods.

        /// <summary>
        ///  Function to generate unique token with expiry against the provided userId.
        ///  Also add a record in database for generated token.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public TokenDTO GenerateToken(int userId)
        {
           
            
            try
            {
                var tokenModel = _tokenDAL.GenerateToken(userId);
                

                return tokenModel;
            }
            catch (Exception ex)
            {
                
                throw ex;
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
                var bResult = _tokenDAL.ValidateToken(tokenId);
                

                return bResult;
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        /// <summary>
        /// Method to kill the provided token id.
        /// </summary>
        /// <param name="tokenId">true for successful delete</param>
        public bool Kill(string tokenId)
        {
           
            try
            {
                var bResult = _tokenDAL.Kill(tokenId);
               

                return bResult;
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        /// <summary>
        /// Delete tokens for the specific deleted user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true for successful delete</returns>
        public bool DeleteByUserId(int userId)
        {
           
            try
            {
                var bResult = _tokenDAL.DeleteByUserId(userId);
               

                return bResult;
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        /// <summary>
        /// Delete tokens for the specific deleted user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true for successful delete</returns>
        public int Authenticate(string userName, string password)
        {
            
            try
            {
                var bResult = _tokenDAL.Authenticate( userName,  password);
               

                return bResult;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        #endregion
    }
}

