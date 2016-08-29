<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="[[ASPX_CS_FILE]]" Inherits="[[NAMESPACE]]" %>


<%@ Register Src="~/controls/admin/metaheader.ascx" TagName="MetaHeader" TagPrefix="WBT" %>
<%@ Register Src="~/controls/admin/header.ascx" TagName="Header" TagPrefix="WBT" %>
<%@ Register Src="~/controls/admin/menu.ascx" TagName="Menu" TagPrefix="WBT" %>
<%@ Register Src="~/controls/admin/pagecontentheader.ascx" TagName="ContentHeader" TagPrefix="WBT" %>
<%@ Register Src="~/controls/admin/footer.ascx" TagName="Footer" TagPrefix="WBT" %>
<%@ Register Src="~/search/bindingmodal.ascx" TagName="Modal" TagPrefix="WBT" %>

<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en">
<!--<![endif]-->
<head id="wbtHeader" runat="server">
    <title><%= Session["WBTPageTitle"] %></title>
    <WBT:MetaHeader ID="metaheader" runat="server"/>
</head>
<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md page-wbt">
<form id="wbtform" runat="server">
<telerik:RadSkinManager ID="PageSkinManager" runat="server" ShowChooser="false"/>
<telerik:RadScriptManager ID="PageRadScriptManager" runat="server">
    <Scripts>
        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"/>
        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"/>
        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"/>

    </Scripts>

</telerik:RadScriptManager>

<telerik:RadAjaxManager ID="PageRadAjaxManager" runat="server" UpdatePanelsRenderMode="Inline" OnAjaxRequest="PageRadAjaxManager_AjaxRequest">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="PageRadAjaxManager">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadTabTheme" />
                <telerik:AjaxUpdatedControl ControlID="RadMultiPageTheme"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadTabTheme">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadTabTheme"/>
                <telerik:AjaxUpdatedControl ControlID="RadMultiPageTheme"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadMultiPageTheme">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadTabTheme"/>
                <telerik:AjaxUpdatedControl ControlID="RadMultiPageTheme"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>

<telerik:RadScriptBlock ID="PageRadScriptBlock" runat="server">
    <script type="text/javascript">

    </script>


</telerik:RadScriptBlock>

<telerik:RadWindowManager ID="PageRadWindowManager" runat="server" KeepInScreenBounds="true" VisibleStatusbar="false" VisibleTitlebar="false" Behaviors="Close" VisibleOnPageLoad="false">
    <Windows>
        <telerik:RadWindow ID="PageRadWindow" runat="server" AutoSize="false" KeepInScreenBounds="true" VisibleStatusbar="false" VisibleTitlebar="true" Behaviors="Close,Move" Modal="true" VisibleOnPageLoad="false"/>
    </Windows>
</telerik:RadWindowManager>

<WBT:Header ID="header" runat="server"/>

<!-- BEGIN CONTAINER -->
<div class="page-container">
    <WBT:Menu ID="menu" runat="server"/>
    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <!-- BEGIN CONTENT BODY -->
        <div class="page-content">
            <WBT:ContentHeader ID="contentheader" runat="server"/>
            <!-- BEGIN PAGE CONTENT -->
            <div class="row">
                <div class="col-md-12">
                    <div class="portlet light portlet-fit">
                        <div class="portlet-body">
                            <div class="row">
								[[MULTIPAGE]]									
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-10 col-xs-9 ">
                    <div class="form-actions noborder">
                        <asp:Button ID="BtnCancel" runat="server" CssClass="btn otherAction" OnClick="BtnCancel_Click"/>
                        <asp:Button ID="BtnSubmit" runat="server" CssClass="btn mainAction" OnClick="BtnSubmit_Click" OnClientClick="if (!checkForm(theForm)) return (false);"/>
                    </div>
                </div>
            </div>
            <!-- END PAGE CONTENT -->
        </div>
        <!-- END CONTENT BODY -->
    </div>
    <!-- BEGIN CONTENT -->
</div>
<!-- END CONTAINER -->

<WBT:Footer ID="footer" runat="server"/>

<div>
    <WBT:Modal ID="modal" runat="server"/>
</div>

<!-- NEEDED FOR BINDING CONTROL -->


<!-- NEEDED FOR BINDING CONTROL -->
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel" runat="server" Transparency="30"/>

</form>

</body>
</html>