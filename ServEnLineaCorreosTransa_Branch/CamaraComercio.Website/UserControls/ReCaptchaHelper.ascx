<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReCaptchaHelper.ascx.cs" Inherits="CamaraComercio.Website.UserControls.ReCaptchaHelper" %>
<%@ Register assembly="ReCaptachaExtended" namespace="ReCaptachaExtended" tagprefix="cc1" %>

    <cc1:RecaptchaControl ID="RecaptchaControl1" runat="server" 
    PublicKey="6LfiCgcAAAAAANjCqsBXVCBig7XdWjOjb0oIbd2b" 
    PrivateKey="6LfiCgcAAAAAAGSckTzj4KhUSdU05xPna8qO1jRW" Lang="es" 
    Theme="clean" />
