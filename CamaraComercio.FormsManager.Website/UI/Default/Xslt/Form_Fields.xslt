<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="html" indent="yes" omit-xml-declaration="yes" media-type="text/html"/>

  <xsl:include href="Field_MultiSelect.xslt"/>
  <xsl:include href="Field_Checkbox.xslt"/>
  <xsl:include href="Field_Text.xslt"/>

  <!-- MAIN FIELD RENDERING TEMPLATE ======================================================================== -->
  <xsl:template name="RENDER_FIELD">
    <xsl:param name="parentId"/>
    <xsl:param name="field"/> <!-- CURRENT NODE -->
    
    <!-- ADD FIELD DEFINITION NAME-->
    <xsl:call-template name="RENDER_HIDDEN_FIELD">
      <xsl:with-param name="name"><xsl:value-of select="$parentId"/>_fields</xsl:with-param>
      <xsl:with-param name="value" select="@id"/>
    </xsl:call-template>

    <!-- ADD INSTANCE COUNTER, IF FIELD ALLOWS MORE THAN ONE INSTANCE-->
    <xsl:call-template name="RENDER_HIDDEN_FIELD">
      <xsl:with-param name="id"><xsl:value-of select="$parentId"/>_<xsl:value-of select="@id"/>_count</xsl:with-param>
      <xsl:with-param name="name"><xsl:value-of select="$parentId"/>_<xsl:value-of select="@id"/>_count</xsl:with-param>
      <xsl:with-param name="value">1</xsl:with-param>
    </xsl:call-template>
    
    <!-- ADD FORM NAME TO NESTED FORM FIELDS LIST, IF NESTED FORM-->
    <xsl:if test="@fieldType='NestedForm'">
      <xsl:call-template name="RENDER_HIDDEN_FIELD">
        <xsl:with-param name="name"><xsl:value-of select="$parentId"/>_nestedform_fields</xsl:with-param>
        <xsl:with-param name="value" select="@id"/></xsl:call-template>      
    </xsl:if>
    
    <tr>
      <td class="DF_label">
        <!-- SHOW FIELD NAME IF TYPE != CHECKBOX -->
        <xsl:if test="@fieldType!='Check'">
          <xsl:value-of select="name"/>
        </xsl:if>
      </td>
      <td class="DF_input">
        <!--USE THIS TEMPLATE IF HAS ONLY ONE INSTANCE-->
        <xsl:if test="@maxInstances=1">
          <xsl:call-template name="FIELD_SELECTOR">
            <xsl:with-param name="parentId" select="$parentId"/>
            <xsl:with-param name="field" select="$field"/>
          </xsl:call-template>
        </xsl:if>

        <!--USE THIS TEMPLATE IF IT CAN HAVE MORE THAN ONE INSTANCE-->
        <xsl:if test="@maxInstances&gt;1">
          <table class="DF_multiInstance_add" style="width:100%;">
            <tr>
              <td colspan="2" class="DF_label" style="text-align:right;">
                <xsl:element name="input">
                  <xsl:attribute name="type">button</xsl:attribute>
                  <xsl:attribute name="name">Add New</xsl:attribute>
                  <xsl:attribute name="value">Add New</xsl:attribute>
                  <xsl:attribute name="onclick">addInstance('<xsl:value-of select="$parentId"/>_<xsl:value-of select="@id"/>',<xsl:value-of select="@maxInstances"/>);</xsl:attribute>
                </xsl:element>
              </td>
            </tr>
            <tr>
              <xsl:attribute name="id"><xsl:value-of select="$parentId"/>_<xsl:value-of select="@id"/>_1</xsl:attribute>
              <td style="vertical-align:top;" class="DF_nestedTable">
                <xsl:call-template name="FIELD_SELECTOR">
                  <xsl:with-param name="parentId" select="$parentId"/>
                  <xsl:with-param name="field" select="$field"/>
                </xsl:call-template>

                <!-- DISPLAY REMOVE BUTTON IN SAME LINE IF IS NOT A FORM-->
                <xsl:if test="$field/@fieldType!='NestedForm'">
                  <input type="button" name="remove" value="remove" onclick="removeInstance(this);"/>
                </xsl:if>

                <!-- DISPLAY REMOVE BUTTON IN OWN TABLE IF IS A FORM-->
                <xsl:if test="$field/@fieldType='NestedForm'">
                  <table style="width:100%;">
                    <tr>
                      <td class="DF_label" style="text-align:right;">
                        <input type="button" name="remove" value="remove" onclick="removeInstance(this);"/>
                      </td>
                    </tr>
                  </table>                  
                </xsl:if>

              </td>
            </tr>
          </table>
        </xsl:if>

      </td>
    </tr>
  </xsl:template>

  <!-- SELECTS TYPE OF INPUT FIELD TO RENDER ================================================================ -->
  <xsl:template name="FIELD_SELECTOR">
    <xsl:param name="parentId"/>
    <xsl:param name="field"/>
    
    <!-- CURRENT NODE -->
    <xsl:choose>
      <!-- TEXT FIELD -->
      <xsl:when test="@fieldType = 'Text'">
        <xsl:call-template name="RENDER_TEXT_FIELD">
          <xsl:with-param name="parentId" select="$parentId"/>
          <xsl:with-param name="field" select="$field"/>
        </xsl:call-template>
      </xsl:when>

      <!-- DROP DOWN FIELD -->
      <xsl:when test="@fieldType = 'DropDown'">
        <xsl:call-template name="RENDER_DROPDOWN_FIELD">
          <xsl:with-param name="parentId" select="$parentId"/>
          <xsl:with-param name="field" select="$field"/>
        </xsl:call-template>
      </xsl:when>

      <!-- CHECK FIELD -->
      <xsl:when test="@fieldType = 'Check'">
        
        <!--RENDER SELECTION STATUS FIELD-->
        <xsl:call-template name="RENDER_HIDDEN_FIELD">
          <xsl:with-param name="name"><xsl:value-of select="concat($parentId,'_',@id,'selected')"/></xsl:with-param>
          <xsl:with-param name="value"><xsl:value-of select="@isChecked"/></xsl:with-param>
        </xsl:call-template>
        
        <xsl:call-template name="RENDER_CHECK_FIELD">
          <xsl:with-param name="parentId" select="$parentId"/>
          <xsl:with-param name="field" select="$field"/>
        </xsl:call-template>
      </xsl:when>

      <!-- NESTED FORM FIELD -->
      <xsl:when test="@fieldType = 'NestedForm'">
        <xsl:call-template name="RENDER_NESTEDFORM_FIELD">
          <xsl:with-param name="parentId" select="$parentId"/>
          <xsl:with-param name="field" select="$field"/>
        </xsl:call-template>
      </xsl:when>
    </xsl:choose>
  </xsl:template>
  
  <!-- RENDER HIDDEN INPUT FIELD ============================================================================ -->
  <xsl:template name="RENDER_HIDDEN_FIELD">
    <xsl:param name="id"/>
    <xsl:param name="name"/>
    <xsl:param name="value"/>

    <xsl:element name="input">
      <xsl:attribute name="type">hidden</xsl:attribute>
      <xsl:attribute name="id"><xsl:value-of select="$id"/></xsl:attribute>
      <xsl:attribute name="name"><xsl:value-of select="$name"/></xsl:attribute>
      <xsl:attribute name="value"><xsl:value-of select="$value"/></xsl:attribute>
    </xsl:element>

  </xsl:template>

  <!-- RENDER NESTED FORM FIELD ============================================================================= -->
  <xsl:template name="RENDER_NESTEDFORM_FIELD">
    <xsl:param name="parentId"/>
    <xsl:param name="field"/>

    <xsl:value-of select="@description"/>
    <!--Form Name-->
    <xsl:call-template name="RENDER_HIDDEN_FIELD">
      <xsl:with-param name="name">FORM_NAME</xsl:with-param>
      <xsl:with-param name="value" select="@id"/>
    </xsl:call-template>

    <table>
      <!-- IF IT HAS 2 OR LESS FIELDS, DISPLAY IN SINGLE ROW-->
      <xsl:if test="count(form/fields/*)&lt;3">
          <xsl:for-each select="form/fields/*">
            <xsl:call-template name="RENDER_FIELD">
              <xsl:with-param name="parentId" select="concat($parentId,'_',$field/@id)"/>
              <xsl:with-param name="field" select="node()"/>
            </xsl:call-template>
          </xsl:for-each>
      </xsl:if>

      <!-- IF IT HAS MORE THAN 2 FIELDS, DISPLAY AS REGULAR FORM-->
      <xsl:if test="count(form/fields/*)&gt;2">
        <xsl:for-each select="form/fields/*">
          <xsl:call-template name="RENDER_FIELD">
              <xsl:with-param name="parentId" select="concat($parentId,'_',$field/@id)"/>
              <xsl:with-param name="field" select="node()"/>
            </xsl:call-template>
        </xsl:for-each>
      </xsl:if>
    </table>
  </xsl:template>
  
</xsl:stylesheet>
