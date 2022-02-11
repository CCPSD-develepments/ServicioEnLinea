<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="html" indent="yes" omit-xml-declaration="yes" media-type="text/html"/>

  <!-- RENDER DROP DOWN FIELD ============================================================================ -->
  <xsl:template name="RENDER_DROPDOWN_FIELD">
    <xsl:param name="parentId"/>
    <xsl:param name="field"/>

      <xsl:element name="select">
        <xsl:attribute name="id"><xsl:value-of select="$parentId"/>_<xsl:value-of select="@id"/>_1</xsl:attribute>
        <xsl:attribute name="name">
          <xsl:value-of select="$parentId"/>_<xsl:value-of select="@id"/>
        </xsl:attribute>

        <xsl:element name="option">
          <xsl:attribute name="value">0</xsl:attribute>
          [Select <xsl:value-of select="name"/>]
        </xsl:element>
        <xsl:for-each select="options/option">

          <xsl:element name="option">
            <xsl:attribute name="value">
              <xsl:value-of select="@value"/>
            </xsl:attribute>
            <xsl:if test="../../values/value/@contents = '' and @selected = 'true'">
              <xsl:attribute name="selected">true</xsl:attribute>
            </xsl:if>
            <xsl:if test="../../values/value/@contents != '' and @value = ../../values/value/@contents">
              <xsl:attribute name="selected">true</xsl:attribute>
            </xsl:if>

            <xsl:value-of select="@name"/>
          </xsl:element>

        </xsl:for-each>

      </xsl:element>

  </xsl:template>
  
</xsl:stylesheet>
