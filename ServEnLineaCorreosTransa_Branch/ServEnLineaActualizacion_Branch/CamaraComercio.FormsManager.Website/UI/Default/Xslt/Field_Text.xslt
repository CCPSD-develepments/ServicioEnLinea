<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="html" indent="yes" omit-xml-declaration="yes" media-type="text/html"/>
  
  <!-- RENDER TEXT FIELD ==================================================================================== -->
  <xsl:template name="RENDER_TEXT_FIELD">
    <xsl:param name="field"/>
    <xsl:param name="parentId"/>

    <!-- LENGHTS LESS THAN 100, USE TEXTBOX-->
    <xsl:if test="@maxLength&lt;102">
    <xsl:element name="input">
      <xsl:attribute name="type">text</xsl:attribute>
      <xsl:attribute name="id"><xsl:value-of select="$parentId"/>_<xsl:value-of select="@id"/>_1</xsl:attribute>
      <xsl:attribute name="name"><xsl:value-of select="$parentId"/>_<xsl:value-of select="@id"/></xsl:attribute>
      <xsl:attribute name="MaxLength"><xsl:value-of select="@maxLength"/></xsl:attribute>
      <xsl:attribute name="value"><xsl:value-of select="values/value/@contents"/></xsl:attribute>
      <xsl:attribute name="style">width:100%;</xsl:attribute>
    </xsl:element>
    </xsl:if>

    <!-- LENGHTS GREATER THAN 100, USE TEXTAREA-->
    <xsl:if test="@maxLength&gt;101">
      <xsl:element name="textarea">
        <xsl:attribute name="style">width:100%;</xsl:attribute>
        <xsl:attribute name="rows">3</xsl:attribute>
        <xsl:attribute name="id"><xsl:value-of select="$parentId"/>_<xsl:value-of select="@id"/>_1</xsl:attribute>
        <xsl:attribute name="name"><xsl:value-of select="$parentId"/>_<xsl:value-of select="@id"/></xsl:attribute>
        <xsl:attribute name="MaxLength"><xsl:value-of select="@maxLength"/></xsl:attribute>
        <xsl:value-of select="values/value/@contents"/>
      </xsl:element>
    </xsl:if>

  </xsl:template>
  
</xsl:stylesheet>
