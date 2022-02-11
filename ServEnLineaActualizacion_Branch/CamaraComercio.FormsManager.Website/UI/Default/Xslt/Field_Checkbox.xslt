<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="html" indent="yes" omit-xml-declaration="yes" media-type="text/html"/>

  <!-- RENDER CHECKBOX FIELD ================================================================================ -->
  <xsl:template name="RENDER_CHECK_FIELD">
    <xsl:param name="parentId"/>
    <xsl:param name="field"/>

    <xsl:element name="input">
      <xsl:attribute name="type">checkbox</xsl:attribute>
      <xsl:attribute name="id"><xsl:value-of select="$parentId"/>_<xsl:value-of select="@id"/>_1</xsl:attribute>
      <xsl:attribute name="name"><xsl:value-of select="$parentId"/>_<xsl:value-of select="@id"/></xsl:attribute>
      <xsl:attribute name="value">
        <xsl:value-of select="defaultValue"/>
      </xsl:attribute>
      <xsl:if test="@isChecked ='true'">
        <xsl:attribute name="checked">true</xsl:attribute>
      </xsl:if>
      <xsl:attribute name="onclick">onCheckboxChanged(this);</xsl:attribute>
    </xsl:element>
    <xsl:value-of select="name"/>

  </xsl:template>
  
</xsl:stylesheet>
