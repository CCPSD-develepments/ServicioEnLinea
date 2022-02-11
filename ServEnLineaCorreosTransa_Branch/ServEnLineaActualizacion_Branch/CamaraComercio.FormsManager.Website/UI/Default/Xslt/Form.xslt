<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:param name="action"/>
  <xsl:param name="baseWebPath"/>
  <xsl:param name="definition"/>
  <xsl:param name="formFile"/>

  <xsl:output method="html" indent="yes" encoding="utf-8" omit-xml-declaration="yes" media-type="text/html"/>

  <!-- INCLUDE ALL ADDITIONAL TEMPLATES =================================================================== -->
  <xsl:include href="Form_Fields.xslt"/>

  <!-- MAIN FORM RENDERING =============================================================================== -->
  <xsl:template match="//dataForm">
    <html>
      <head>
        <base>
          <xsl:attribute name="href">
            <xsl:value-of select="$baseWebPath"/>
          </xsl:attribute>
        </base>
        <link href="form.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../Common/js/Ext.js" />
        <script type="text/javascript" src="../Common/js/form.js" />
        <script type="text/javascript">
          function validateForm(form)
          {
          var isValid = true;
          <xsl:for-each select="fields/*">
            <xsl:variable name="parentId" select="//dataForm/@id"/>
            <xsl:variable name="field" select="node()"/>

          <xsl:if test="@isMandatory = 'true'">
          <xsl:choose>
            <!-- TEXT FIELD -->
            <xsl:when test="@fieldType = 'Text'">
          isValid = isValid &amp;&amp; validateTextbox('<xsl:value-of select="$parentId"/>_<xsl:value-of select="@id"/>_1','<xsl:value-of select="name"/>');
            </xsl:when>

            <!-- DROP DOWN FIELD -->
            <xsl:when test="@fieldType = 'DropDown'">
          isValid = isValid &amp;&amp; validateCombo('<xsl:value-of select="$parentId"/>_<xsl:value-of select="@id"/>_1','<xsl:value-of select="name"/>');
            </xsl:when>

            <!-- CHECK FIELD -->
            <xsl:when test="@fieldType = 'Check'">
          isValid = isValid &amp;&amp; validateTextbox('<xsl:value-of select="$parentId"/>_<xsl:value-of select="@id"/>_1','<xsl:value-of select="name"/>');
            </xsl:when>
                
          </xsl:choose>
          </xsl:if>              
        </xsl:for-each>

          if(!isValid)
          {
          alert(errorMessage);
          }
          else
          {
          alert('Everything is OK!');
          }
          errorMessage = '';
          return isValid;
          }

        </script>
      </head>
      <body>
        <form id="dataForm" name="dataForm" onsubmit="return validateForm(this)" method="post">
          <xsl:attribute name="action">../../<xsl:value-of select="$action"/></xsl:attribute>

          <xsl:call-template name="RENDER_HIDDEN_FIELD">
            <xsl:with-param name="name">MAIN_FORM</xsl:with-param>
            <xsl:with-param name="value" select="@id"/>
          </xsl:call-template>
          
          <xsl:call-template name="RENDER_HIDDEN_FIELD">
            <xsl:with-param name="name">FILE_PATH</xsl:with-param>
            <xsl:with-param name="value" select="$formFile"/>
          </xsl:call-template>
          
          <xsl:call-template name="RENDER_HIDDEN_FIELD">
            <xsl:with-param name="name">FORM_DEFINITION</xsl:with-param>
            <xsl:with-param name="value" select="$definition"/>
          </xsl:call-template>

          <table cellspacing="0" cellpadding="5" border="0" style="min-width:50%;">
            <tr>
              <td style="padding:0px;height:5px;width:5px; background: #fff url(img/brGrayLeftTop.gif) no-repeat top right;"></td>
              <td style="padding:0px;height:5px;background: #fff url(img/shwGrayTop.gif) repeat-x top;"></td>
              <td style="padding:0px;height:5px;background: #fff url(img/shwGrayTop.gif) repeat-x top;"></td>
              <td style="padding:0px;height:5px;width:5px; background: #fff url(img/brGrayRightTop.gif) no-repeat top left;"></td>
            </tr>      
            <tr>
              <td style="background: #fff url(img/shwGrayLeft.gif) repeat-y right;"></td>
              <td class="DF_title"><span class="DF_title_text"><xsl:value-of select="name"/></span></td>
              <td class="DF_title"></td>
              <td style="background: #fff url(img/shwGrayRight.gif) repeat-y;"></td>
            </tr>
            <tr>
              <td style="background: #fff url(img/shwWhiteLeft.gif) repeat-y right;"></td>
              <td style="left-padding:15px;" rowspan="2">
                <div class="DF_instructions" >
                  <i class="DF_instructions_text">
                    <xsl:value-of select="instructions"/>
                  </i>
                </div>
              </td>
              <td style="padding:5px;">
                <i class="DF_instructions_text">
                  <xsl:value-of select="description"/>
                </i><br/>
                <table class="DF_Table">
                  <!-- CALL MAIN FIELD RENDERER FOR EACH FIELD IN THE FORM -->
                    <xsl:for-each select="fields/*">
                    <xsl:call-template name="RENDER_FIELD">
                      <xsl:with-param name="parentId" select="//dataForm/@id"/>
                      <xsl:with-param name="field" select="node()"/>
                    </xsl:call-template>
                  </xsl:for-each>
                </table>
              </td>
              <td style="background: #fff url(img/shwWhiteRight.gif) repeat-y;"></td>
            </tr>
            <tr>
              <td style="width:5px; background: #fff url(img/shwWhiteLeft.gif) repeat-y right;"></td>
              <td style="padding:5px;text-align:right;border-top: solid 1px #f2f2f2;"><input type="submit" name="Submit" value="Submit"/></td>
              <td style="width:5px; background: #fff url(img/shwWhiteRight.gif) repeat-y;"></td>
            </tr>
            <tr>
              <td style="width:5px; background: #fff url(img/brWhiteLeftBottom.gif) no-repeat top right;"></td>
              <td style="height:5px; background: #fff url(img/shwWhiteBottom.gif) repeat-x;"></td>
              <td style="height:5px; background: #fff url(img/shwWhiteBottom.gif) repeat-x;"></td>
              <td style="width:5px; background: #fff url(img/brWhiteRightBottom.gif) no-repeat top left;"></td>
            </tr>
          </table>
        </form>
      </body>
    </html>
  </xsl:template>
  
</xsl:stylesheet>
