UPDATE [CamaraMailbot].[dbo].[Templates]
SET TemplateText = '<h4>Hola [NombreSolicitante]</h4>
<p>
  Estas recibiendo este mensaje para confirmar tu nuevo usuario ([UserName])
  para <a href="http://www.camarasantodomingo.do">Camarasantodomingo.do</a>
  <br />
  <br />
  Por favor inicia sesión en <a href="[Link]">[Link]</a> para activar tu usuario
  <br />
  <br />
  Tu contaseña es: <b>[TempPassword]</b>
</p>
'
WHERE TemplateCode = 'NUH'