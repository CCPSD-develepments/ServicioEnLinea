namespace CamaraComercio.Website.Helpers
{
    /// <summary>
    /// functionality to prepare and send mails
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Sends the registration information to the username
        /// </summary>
        /// <param name="email">
        /// User's email
        /// </param>
        /// <param param name="fullName">
        /// User's fullname
        /// </param>
        /// <param name="userName">
        /// User's username
        /// </param>
        /// <param name="password">
        /// User's password
        /// </param>
        /// <param name="confirmationCode">
        /// Confirmation code
        /// </param>
        void SendRegistrationInfo(string email, string userName, string password, string serverName, string confirmationCode);

        /// <summary>
        /// Notifies the account activation after confirmation
        /// </summary>
        /// <param name="email">
        /// User's email
        /// </param>
        /// <param name="userName">
        /// Username
        /// </param>
        void SendConfirmationMail(string email, string userName);

        /// <summary>
        /// Sends the new password after a password reset
        /// </summary>
        /// <param name="email">
        /// User's email
        /// </param>
        /// <param name="userName">
        /// Username
        /// </param>
        /// <param name="password">
        /// New password
        /// </param>
        void SendNewPassword(string email, string userName, string password);
        
        /// <summary>
        /// Notifies the author of an article that somebody commented
        /// one of his publications
        /// </summary>
        /// <param name="email">
        /// User's Email
        /// </param>
        /// <param name="articlePermaLink">
        /// Article permalink
        /// </param>
        /// <param name="userName">
        /// Username of the user who made the comment
        /// </param>
        /// <param name="comment">
        /// Comment body
        /// </param>
        void SendArticleComment(string email, string articlePermaLink, string userName, string comment);

        /// <summary>
        /// Notifies the author of an article that somebody commented
        /// one of his publications
        /// </summary>
        /// <param name="email">
        /// User's Email
        /// </param>
        /// <param name="commentPermaLink">
        /// Comment permalink
        /// </param>
        /// <param name="userName">
        /// Username of the user who made the comment
        /// </param>
        /// <param name="comment">
        /// Comment body
        /// </param>
        void SendChildComment(string email, string commentPermaLink, string userName, string comment);

        void FanFeedback();
        void BestArticles();
        void NewsLetter();
        void ResendEmailConfirmationKey(string email, string userName, string serverName, string emailConfirmationKey);
    }
}
