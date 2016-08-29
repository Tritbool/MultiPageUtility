using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using ASP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WBTMigration.Parsing;
using WBTMigration.Writing;

namespace Testing
{
    [TestClass]
    public class TestASPX2XML
    {
        [TestMethod]
        public void TestMultiple35ToXml()
        {


            string asp =
"﻿<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"user.aspx.cs\" Inherits=\"WBTManager.manageUser.user\" %>" +

"<%@ Register Src=\"~/controls/common/metaheader.ascx\" TagName=\"MetaHeader\" TagPrefix=\"WBT\" %>" +

"<%@ Register Src=\"~/controls/telerik/RadWindowTranslation.ascx\" TagName=\"RadWindowTranslation\" TagPrefix=\"WBT\" %>" +


"<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">" +

"<html xmlns=\"http://www.w3.org/1999/xhtml\">" +

"<head id=\"wbtHeader\" runat=\"server\">" +

"    <title></title>" +

"    <WBT:MetaHeader id=\"metaheader\" runat=\"server\"/>" +

"    <style type=\"text/css\">" +

"        #LblManagerNamePanel { float: left; }" +


"        #LblAlternateManagerNamePanel { float: left; }" +

"    </style>" +

"</head>" +

"<body class=\"admin\" onload=\" /*passwordChanged();*/\">" +

"<form id=\"wbtform\" runat=\"server\">" +

"<telerik:RadSkinManager ID=\"PageSkinManager\" runat=\"server\" ShowChooser=\"false\"/>" +

"<telerik:RadScriptManager ID=\"PageRadScriptManager\" runat=\"server\">" +

"    <Scripts>" +

"        <asp:ScriptReference Assembly=\"Telerik.Web.UI\" Name=\"Telerik.Web.UI.Common.Core.js\"/>" +

"        <asp:ScriptReference Assembly=\"Telerik.Web.UI\" Name=\"Telerik.Web.UI.Common.jQuery.js\"/>" +

"        <asp:ScriptReference Assembly=\"Telerik.Web.UI\" Name=\"Telerik.Web.UI.Common.jQueryInclude.js\"/>" +

"    </Scripts>" +

"</telerik:RadScriptManager>" +

"<telerik:RadAjaxManager ID=\"PageRadAjaxManager\" runat=\"server\" OnAjaxRequest=\"PageRadAjaxManager_AjaxRequest\">" +

"    <AjaxSettings>" +

"        <telerik:AjaxSetting AjaxControlID=\"PageRadAjaxManager\">" +

"            <UpdatedControls>" +

"                <telerik:AjaxUpdatedControl ControlID=\"TableBlocked\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"                <telerik:AjaxUpdatedControl ControlID=\"AudRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"                <telerik:AjaxUpdatedControl ControlID=\"CrsRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"                <telerik:AjaxUpdatedControl ControlID=\"ClsRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"                <telerik:AjaxUpdatedControl ControlID=\"SessionRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"                <telerik:AjaxUpdatedControl ControlID=\"TraningPlanRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"                <telerik:AjaxUpdatedControl ControlID=\"RoleRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"                <telerik:AjaxUpdatedControl ControlID=\"PermRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"                <telerik:AjaxUpdatedControl ControlID=\"ManagedUserRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"                <telerik:AjaxUpdatedControl ControlID=\"AlternateManagedUserRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"                <telerik:AjaxUpdatedControl ControlID=\"TutorCrsRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"                <telerik:AjaxUpdatedControl ControlID=\"TutorClsRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"                <telerik:AjaxUpdatedControl ControlID=\"LblManagerName\"/>" +

"                <telerik:AjaxUpdatedControl ControlID=\"LblAlternateManagerName\"/>" +

"            </UpdatedControls>" +

"        </telerik:AjaxSetting>" +

"        <telerik:AjaxSetting AjaxControlID=\"AudRadGrid\">" +

"            <UpdatedControls>" +

"                <telerik:AjaxUpdatedControl ControlID=\"AudRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"            </UpdatedControls>" +

"        </telerik:AjaxSetting>" +

"        <telerik:AjaxSetting AjaxControlID=\"CrsRadGrid\">" +

"            <UpdatedControls>" +

"                <telerik:AjaxUpdatedControl ControlID=\"CrsRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"            </UpdatedControls>" +

"        </telerik:AjaxSetting>" +

"        <telerik:AjaxSetting AjaxControlID=\"ClsRadGrid\">" +

"            <UpdatedControls>" +

"                <telerik:AjaxUpdatedControl ControlID=\"ClsRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"            </UpdatedControls>" +

"        </telerik:AjaxSetting>" +

"        <telerik:AjaxSetting AjaxControlID=\"SessionRadGrid\">" +

"            <UpdatedControls>" +

"                <telerik:AjaxUpdatedControl ControlID=\"SessionRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"            </UpdatedControls>" +

"        </telerik:AjaxSetting>" +

"        <telerik:AjaxSetting AjaxControlID=\"TraningPlanRadGrid\">" +

"            <UpdatedControls>" +

"                <telerik:AjaxUpdatedControl ControlID=\"TraningPlanRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"            </UpdatedControls>" +

"        </telerik:AjaxSetting>" +

"        <telerik:AjaxSetting AjaxControlID=\"RoleRadGrid\">" +

"            <UpdatedControls>" +

"                <telerik:AjaxUpdatedControl ControlID=\"RoleRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"            </UpdatedControls>" +

"        </telerik:AjaxSetting>" +

"        <telerik:AjaxSetting AjaxControlID=\"PermRadGrid\">" +

"            <UpdatedControls>" +

"                <telerik:AjaxUpdatedControl ControlID=\"PermRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"            </UpdatedControls>" +

"        </telerik:AjaxSetting>" +

"        <telerik:AjaxSetting AjaxControlID=\"ManagedUserRadGrid\">" +

"            <UpdatedControls>" +

"                <telerik:AjaxUpdatedControl ControlID=\"ManagedUserRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"            </UpdatedControls>" +

"        </telerik:AjaxSetting>" +

"        <telerik:AjaxSetting AjaxControlID=\"AlternateManagedUserRadGrid\">" +

"            <UpdatedControls>" +

"                <telerik:AjaxUpdatedControl ControlID=\"AlternateManagedUserRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"            </UpdatedControls>" +

"        </telerik:AjaxSetting>" +

"        <telerik:AjaxSetting AjaxControlID=\"TutorCrsRadGrid\">" +

"            <UpdatedControls>" +

"                <telerik:AjaxUpdatedControl ControlID=\"TutorCrsRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"            </UpdatedControls>" +

"        </telerik:AjaxSetting>" +

"        <telerik:AjaxSetting AjaxControlID=\"TutorClsRadGrid\">" +

"            <UpdatedControls>" +

"                <telerik:AjaxUpdatedControl ControlID=\"TutorClsRadGrid\" LoadingPanelID=\"WindowRadAjaxLoadingPanel\"/>" +

"            </UpdatedControls>" +

"        </telerik:AjaxSetting>" +

"    </AjaxSettings>" +

"</telerik:RadAjaxManager>" +

"<telerik:RadScriptBlock ID=\"PageRadScriptBlock\" runat=\"server\">" +

"<script type=\"text/javascript\">" +


"    var theForm = document.getElementById('wbtform');" +

"    var bPwdChanged = false;" +


"    function checkForm(pForm) {" +

"        var bTest = true;" +

"        if (bTest && isEmpty(pForm.<%= TxtFname.ClientID %>)) {" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgCheckFname\", oUser.Subdomain) %>', '', 300, 100);" +

"            pForm.<%= TxtFname.ClientID %>.focus();" +

"            bTest = false;" +


"        if (bTest && isEmpty(pForm.<%= TxtLname.ClientID %>)) {" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgCheckLname\", oUser.Subdomain) %>', '', 300, 100);" +

"            pForm.<%= TxtLname.ClientID %>.focus();" +

"            bTest = false;" +


"        if (bTest && isEmpty(pForm.<%= TxtLogin.ClientID %>)) {" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgCheckLogin\", oUser.Subdomain) %>', '', 300, 100);" +

"            pForm.<%= TxtLogin.ClientID %>.focus();" +

"            bTest = false;" +


"        if (bTest && isEmpty(pForm.<%= TxtPassword.ClientID %>)) {" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgCheckPwd\", oUser.Subdomain) %>', '', 300, 100);" +

"            pForm.<%= TxtPassword.ClientID %>.focus();" +

"            bTest = false;" +


"        if (bTest && pForm.<%= TxtPassword.ClientID %>.value != pForm.<%= TxtPasswordConfirm.ClientID %>.value) {" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgCheckPwdConfirm\", oUser.Subdomain) %>', '', 300, 100);" +

"            pForm.<%= TxtPasswordConfirm.ClientID %>.focus();" +

"            bTest = false;" +


"        if (bTest && bPwdChanged) {" +

"            if (!passwordChanged(<%= nPasswordStrenght %>)) {" +

"                if (<%= nPasswordStrenght %> == 3)" +

"                    WbtRadAlert('<%= oLoc.GetStringJS(\"MsgCheckPwdStrengthStrong\", oUser.Subdomain) %>', '', 300, 100);" +

"                else if (<%= nPasswordStrenght %> == 2)" +

"                    WbtRadAlert('<%= oLoc.GetStringJS(\"MsgCheckPwdStrengthMedium\", oUser.Subdomain) %>', '', 300, 100);" +

"                else" +

"                    WbtRadAlert('<%= oLoc.GetStringJS(\"MsgCheckPwdStrengthWeak\", oUser.Subdomain) %>', '', 300, 100);" +

"                pForm.<%= TxtPassword.ClientID %>.focus();" +

"                bTest = false;" +



"        if (bTest && !isEmpty(pForm.<%= TxtEmail.ClientID %>) && !isEmail(pForm.<%= TxtEmail.ClientID %>)) {" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgCheckEmail\", oUser.Subdomain) %>', '', 300, 100);" +

"            pForm.<%= TxtEmail.ClientID %>.focus();" +

"            bTest = false;" +


"        var dActivation = $find(\"<%= RadDateActivation.ClientID %>\");" +

"        var dExpiration = $find(\"<%= RadDateExpiration.ClientID %>\");" +

"        if (!dActivation.isEmpty() && !dExpiration.isEmpty()) {" +

"            if (dActivation.get_selectedDate() > dExpiration.get_selectedDate()) {" +

"                WbtRadAlert('<%= oLoc.GetStringJS(\"MsgCheckActivationExpirationDate\", oUser.Subdomain) %>'," +




"                bTest = false;" +



"        return bTest;" +



"    function passwordChanged(strenght) {" +

"        bPwdChanged = true;" +

"        var strengthDiv = document.getElementById('PasswordStrenght');" +

"        var enoughRegex = new RegExp('<%= sPasswordStrenghtWeak %>', 'g');" +

"        var mediumRegex = new RegExp('<%= sPasswordStrenghtMedium %>', 'g');" +

"        var strongRegex = new RegExp('<%= sPasswordStrenghtStrong %>', 'g');" +

"        var pwd = document.getElementById('TxtPassword');" +

"        if (strenght == 1) {" +

"            if (enoughRegex.test(pwd.value))" +

"                return true;" +

"            else" +

"                return false;" +

"        } else if (strenght == 2) {" +

"            if (mediumRegex.test(pwd.value))" +

"                return true;" +

"            else" +

"                return false;" +

"        } else if (strenght == 3) {" +

"            if (strongRegex.test(pwd.value))" +

"                return true;" +

"            else" +

"                return false;" +

"        } else {" +

"            if (pwd.value.length == 0)" +

"                strengthDiv.innerHTML = '<%= oLoc.GetStringJS(\"LblPasswordStrengthNull\", oUser.Subdomain) %>';" +

"            else if (false == enoughRegex.test(pwd.value))" +

"                strengthDiv.innerHTML = '<%= oLoc.GetStringJS(\"LblPasswordStrengthNull\", oUser.Subdomain) %>';" +

"            else if (strongRegex.test(pwd.value))" +

"                strengthDiv" +

"                    .innerHTML =" +

"                    '<span style=\"color:green\"><%= oLoc.GetStringJS(\"LblPasswordStrengthStrong\", oUser.Subdomain) %></span>';" +

"            else if (mediumRegex.test(pwd.value))" +

"                strengthDiv" +

"                    .innerHTML =" +

"                    '<span style=\"color:orange\"><%= oLoc.GetStringJS(\"LblPasswordStrengthMedium\", oUser.Subdomain) %></span>';" +

"            else" +

"                strengthDiv" +

"                    .innerHTML =" +

"                    '<span style=\"color:red\"><%= oLoc.GetStringJS(\"LblPasswordStrengthWeak\", oUser.Subdomain) %></span>';" +

"            return true;" +




"    function onTabSelecting(sender, args) {" +

"        var tabStrip = $find(\"<%= RadTabUser.ClientID %>\");" +

"        var tabInfo = tabStrip.findTabByValue('user_info_tab');" +

"        var tabNext = args.get_tab().get_value();" +

"        var tmp = true;" +

"        if (tabInfo.get_selected())" +

"            tmp = checkForm(theForm);" +

"        if (!tmp)" +

"            args.set_cancel(true);" +

"        else if (<%= nUserId %> == 0) {" +

"            args.set_cancel(true);" +

"            SelectNext(tabNext, '');" +




"    function SelectNext(pTab, pAction) {" +

"        var dBirth = $find(\"<%= RadDateBirth.ClientID %>\");" +

"        var dActivation = $find(\"<%= RadDateActivation.ClientID %>\");" +

"        var dExpiration = $find(\"<%= RadDateExpiration.ClientID %>\");" +

"        var dtBirth = '';" +

"        var dtActivation = '';" +

"        var dtExpiration = '';" +

"        if (!dBirth.isEmpty())" +

"            dtBirth = dBirth.get_selectedDate().format('<%= sDateFormat %>');" +

"        if (!dActivation.isEmpty())" +

"            dtActivation = dActivation.get_selectedDate().format('<%= sDateFormat %>');" +

"        if (!dExpiration.isEmpty())" +

"            dtExpiration = dExpiration.get_selectedDate().format('<%= sDateFormat %>');" +

"        var nHourlyCost = $find(\"<%= TxtHourlyCost.ClientID %>\");" +

"        var wbtAjaxArgs = 'Create||' +" +

"            theForm.<%= ChkUserDisabled.ClientID %>.checked +" +


"            theForm.<%= TxtLogin.ClientID %>.value +" +


"            theForm.<%= TxtPassword.ClientID %>.value +" +


"            theForm.<%= ChkChangePassword.ClientID %>.checked +" +


"            $find(\"<%= cboTname.ClientID %>\").get_value() +" +


"            theForm.<%= TxtFname.ClientID %>.value +" +


"            theForm.<%= TxtLname.ClientID %>.value +" +


"            theForm.<%= TxtExtid.ClientID %>.value +" +


"            $find(\"<%= cboLanguage.ClientID %>\").get_value() +" +


"            dtBirth +" +


"            dtActivation +" +


"            dtExpiration +" +


"            theForm.<%= TxtEmail.ClientID %>.value +" +


"            nHourlyCost.get_value() +" +


"            theForm.<%= TxtAddress1.ClientID %>.value +" +


"            theForm.<%= TxtAddress2.ClientID %>.value +" +


"            theForm.<%= TxtZipCode.ClientID %>.value +" +


"            theForm.<%= TxtCity.ClientID %>.value +" +


"            theForm.<%= TxtCountry.ClientID %>.value +" +


"            theForm.<%= TxtPhone.ClientID %>.value +" +


"            theForm.<%= TxtCellphone.ClientID %>.value +" +


"            pTab +" +


"            pAction;" +

"        var ajaxManager = $find(\"<%= PageRadAjaxManager.ClientID %>\");" +

"        ajaxManager.ajaxRequest(wbtAjaxArgs);" +



"    function selectTab(tabName) {" +

"        var tabStrip = $find(\"<%= RadTabUser.ClientID %>\");" +

"        if (tabStrip) {" +

"            var tab = tabStrip.findTabByValue(tabName);" +

"            if (tab)" +

"                tab.select();" +




"    function changeLogin() {" +

"        if (!isEmpty(theForm.<%= TxtLogin.ClientID %>)) {" +

"            var wbtAjaxArgs = 'CheckLogin||' + theForm.<%= TxtLogin.ClientID %>.value;" +

"            var ajaxManager = $find(\"<%= PageRadAjaxManager.ClientID %>\");" +

"            ajaxManager.ajaxRequest(wbtAjaxArgs);" +




"    function changeExtid() {" +

"        if (!isEmpty(theForm.<%= TxtExtid.ClientID %>)) {" +

"            var wbtAjaxArgs = 'CheckExtid||' + theForm.<%= TxtExtid.ClientID %>.value;" +

"            var ajaxManager = $find(\"<%= PageRadAjaxManager.ClientID %>\");" +

"            ajaxManager.ajaxRequest(wbtAjaxArgs);" +




"    function LoginExtidChangeChecked(pType) {" +

"        if (pType == 'Login')" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgLoginDuplicate\", oUser.Subdomain) %>', '', 300, 100);" +

"        else if (pType == 'Extid')" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgExtidDuplicate\", oUser.Subdomain) %>', '', 300, 100);" +



"    function UserCreationError() {" +

"        WbtRadAlert('<%= oLoc.GetStringJS(\"MsgUserCreationError\", oUser.Subdomain) %>', '', 300, 100);" +



"    function ClearDate(DatePickerId) {" +

"        var RadDatePicker = null;" +

"        if (DatePickerId == 'Birth')" +

"            RadDatePicker = $find(\"<%= RadDateBirth.ClientID %>\");" +

"        else if (DatePickerId == 'Activation')" +

"            RadDatePicker = $find(\"<%= RadDateActivation.ClientID %>\");" +

"        else if (DatePickerId == 'Expiration')" +

"            RadDatePicker = $find(\"<%= RadDateExpiration.ClientID %>\");" +

"        if (RadDatePicker != null)" +

"            RadDatePicker.clear();" +



"    function ShowDatePopup(DatePickerId) {" +

"        var RadDatePicker = null;" +

"        if (DatePickerId == 'Birth')" +

"            RadDatePicker = $find(\"<%= RadDateBirth.ClientID %>\");" +

"        else if (DatePickerId == 'Activation')" +

"            RadDatePicker = $find(\"<%= RadDateActivation.ClientID %>\");" +

"        else if (DatePickerId == 'Expiration')" +

"            RadDatePicker = $find(\"<%= RadDateExpiration.ClientID %>\");" +

"        if (RadDatePicker != null)" +

"            RadDatePicker.showPopup();" +



"    function selectManager() {" +

"        if (<%= nUserId %> == 0) {" +

"            var tmp = checkForm(theForm);" +

"            if (tmp)" +

"                SelectNext('', 'selectManager');" +

"        } else {" +

"            var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"            oWnd.show();" +

"            oWnd.setSize(800, 500);" +

"            oWnd.center();" +

"            oWnd.set_title('<%= oLoc.GetStringJS(\"LblAddUserManager\", oUser.Subdomain) %>');" +

"            oWnd.setUrl('../search/users.aspx?action=selectmanager&userid=<%= nUserId %>');" +

"            oWnd.add_close(OnClose);" +




"    function deleteManager() {" +

"        $find(\"<%= PageRadAjaxManager.ClientID %>\").ajaxRequest(\"DeleteManager\");" +



"    function RefreshManager(params) {" +

"        var wbtAjaxArgs = 'RefreshManager||' + params;" +

"        var ajaxManager = $find(\"<%= PageRadAjaxManager.ClientID %>\");" +

"        ajaxManager.ajaxRequest(wbtAjaxArgs);" +



"    function selectAlternateManager() {" +

"        if (<%= nUserId %> == 0) {" +

"            var tmp = checkForm(theForm);" +

"            if (tmp)" +

"                SelectNext('', 'selectAlternateManager');" +

"        } else {" +

"            var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"            oWnd.show();" +

"            oWnd.setSize(800, 500);" +

"            oWnd.center();" +

"            oWnd.set_title('<%= oLoc.GetStringJS(\"LblAddUserAlternateManager\", oUser.Subdomain) %>');" +

"            oWnd.setUrl('../search/users.aspx?action=selectalternatemanager&userid=<%= nUserId %>');" +

"            oWnd.add_close(OnClose);" +




"    function deleteAlternateManager() {" +

"        $find(\"<%= PageRadAjaxManager.ClientID %>\").ajaxRequest(\"DeleteAlternateManager\");" +



"    function RefreshAlternateManager(params) {" +

"        var wbtAjaxArgs = 'RefreshAlternateManager||' + params;" +

"        var ajaxManager = $find(\"<%= PageRadAjaxManager.ClientID %>\");" +

"        ajaxManager.ajaxRequest(wbtAjaxArgs);" +



"    function addAud() {" +

"        var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"        oWnd.show();" +

"        oWnd.setSize(850, 560);" +

"        oWnd.center();" +

"        oWnd.set_title('<%= oLoc.GetStringJS(\"LblAddUserAud\", oUser.Subdomain) %>');" +

"        oWnd.setUrl('../search/audience.aspx?userid=<%= nUserId %>');" +

"        oWnd.add_close(OnClose);" +



"    function dropAud() {" +

"        var grid = $find(\"<%= AudRadGrid.ClientID %>\");" +

"        var gridSelectedItems = grid.get_selectedItems();" +

"        if (gridSelectedItems.length == 0)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgAudienceCheckOneSelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else {" +

"            var list = getSelectedElementList(gridSelectedItems, 'ID');" +

"            var wbtAjaxArgs = 'DropAudience||' + list;" +

"            var ajaxManager = $find(\"<%= PageRadAjaxManager.ClientID %>\");" +

"            ajaxManager.ajaxRequest(wbtAjaxArgs);" +




"    function RefreshAudGrid() {" +

"        $find(\"<%= PageRadAjaxManager.ClientID %>\").ajaxRequest(\"RefreshAud\");" +



"    function addCrs() {" +

"        var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"        oWnd.show();" +

"        oWnd.setSize(850, 560);" +

"        oWnd.center();" +

"        oWnd.set_title('<%= oLoc.GetStringJS(\"LblAddUserCrs\", oUser.Subdomain) %>');" +

"        oWnd.setUrl('../search/courses.aspx?userid=<%= nUserId %>');" +

"        oWnd.add_close(OnClose);" +



"    function dropCrs() {" +

"        var grid = $find(\"<%= CrsRadGrid.ClientID %>\");" +

"        var gridSelectedItems = grid.get_selectedItems();" +

"        if (gridSelectedItems.length == 0)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgCourseCheckOneSelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else {" +

"            var list = getSelectedElementList(gridSelectedItems, 'CRS_ID');" +

"            var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"            oWnd.show();" +

"            oWnd.setSize(640, 200);" +

"            oWnd.center();" +

"            oWnd.set_title('<%= oLoc.GetStringJS(\"LblDropUserCrs\", oUser.Subdomain) %>');" +

"            oWnd.setUrl('user_crsclsdropreset.aspx?target=crs&userid=<%= nUserId %>&list=' + list);" +

"            oWnd.add_close(OnClose);" +




"    function editCrs() {" +

"        var grid = $find(\"<%= CrsRadGrid.ClientID %>\");" +

"        var gridSelectedItems = grid.get_selectedItems();" +

"        if (gridSelectedItems.length == 0)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgCourseCheckOneSelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else if (gridSelectedItems.length > 1)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgCourseCheckOneOnlySelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else {" +

"            var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"            oWnd.show();" +

"            oWnd.setSize(850, 560);" +

"            oWnd.center();" +

"            oWnd.set_title('<%= oLoc.GetStringJS(\"LblEditUserCrs\", oUser.Subdomain) %>');" +

"            oWnd.setUrl('user_crsclsedit.aspx?target=usercrs&userid=<%= nUserId %>&id=' +" +

"                gridSelectedItems[0].getDataKeyValue('CRS_ID'));" +

"            oWnd.add_close(OnClose);" +




"    function resetCrs() {" +

"        var grid = $find(\"<%= CrsRadGrid.ClientID %>\");" +

"        var gridSelectedItems = grid.get_selectedItems();" +

"        if (gridSelectedItems.length == 0)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgCourseCheckOneSelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else {" +

"            var list = getSelectedElementList(gridSelectedItems, 'CRS_ID');" +

"            var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"            oWnd.show();" +

"            oWnd.setSize(640, 200);" +

"            oWnd.center();" +

"            oWnd.set_title('<%= oLoc.GetStringJS(\"LblResetUserCrs\", oUser.Subdomain) %>');" +

"            oWnd.setUrl('user_crsclsdropreset.aspx?target=crs&action=reset&userid=<%= nUserId %>&list=' + list);" +

"            oWnd.add_close(OnClose);" +




"    function RefreshCrsGrid() {" +

"        $find(\"<%= PageRadAjaxManager.ClientID %>\").ajaxRequest(\"RefreshCrs\");" +



"    function changeCoursesDisplay(bChecked) {" +

"        var wbtAjaxArgs = 'DisplayCompletedCourses||' + bChecked;" +

"        var ajaxManager = $find(\"<%= PageRadAjaxManager.ClientID %>\");" +

"        ajaxManager.ajaxRequest(wbtAjaxArgs);" +



"    function addCls() {" +

"        var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"        oWnd.show();" +

"        oWnd.setSize(850, 560);" +

"        oWnd.center();" +

"        oWnd.set_title('<%= oLoc.GetStringJS(\"LblAddUserCls\", oUser.Subdomain) %>');" +

"        oWnd.setUrl('../search/classes.aspx?userid=<%= nUserId %>');" +

"        oWnd.add_close(OnClose);" +



"    function dropCls() {" +

"        var grid = $find(\"<%= ClsRadGrid.ClientID %>\");" +

"        var gridSelectedItems = grid.get_selectedItems();" +

"        if (gridSelectedItems.length == 0)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgClasseCheckOneSelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else {" +

"            var list = getSelectedElementList(gridSelectedItems, 'CLS_ID');" +

"            var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"            oWnd.show();" +

"            oWnd.setSize(640, 200);" +

"            oWnd.center();" +

"            oWnd.set_title('<%= oLoc.GetStringJS(\"LblDropUserCls\", oUser.Subdomain) %>');" +

"            oWnd.setUrl('user_crsclsdropreset.aspx?target=cls&userid=<%= nUserId %>&list=' + list);" +

"            oWnd.add_close(OnClose);" +




"    function editCls() {" +

"        var grid = $find(\"<%= ClsRadGrid.ClientID %>\");" +

"        var gridSelectedItems = grid.get_selectedItems();" +

"        if (gridSelectedItems.length == 0)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgClasseCheckOneSelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else if (gridSelectedItems.length > 1)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgClasseCheckOneOnlySelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else {" +

"            var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"            oWnd.show();" +

"            oWnd.setSize(850, 560);" +

"            oWnd.center();" +

"            oWnd.set_title('<%= oLoc.GetStringJS(\"LblEditUserCls\", oUser.Subdomain) %>');" +

"            oWnd.setUrl('user_crsclsedit.aspx?target=usercls&userid=<%= nUserId %>&id=' +" +

"                gridSelectedItems[0].getDataKeyValue('CLS_ID'));" +

"            oWnd.add_close(OnClose);" +




"    function resetCls() {" +

"        var grid = $find(\"<%= ClsRadGrid.ClientID %>\");" +

"        var gridSelectedItems = grid.get_selectedItems();" +

"        if (gridSelectedItems.length == 0)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgClasseCheckOneSelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else {" +

"            var list = getSelectedElementList(gridSelectedItems, 'CLS_ID');" +

"            var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"            oWnd.show();" +

"            oWnd.setSize(640, 200);" +

"            oWnd.center();" +

"            oWnd.set_title('<%= oLoc.GetStringJS(\"LblResetUserCls\", oUser.Subdomain) %>');" +

"            oWnd.setUrl('user_crsclsdropreset.aspx?target=cls&action=reset&userid=<%= nUserId %>&list=' + list);" +

"            oWnd.add_close(OnClose);" +




"    function RefreshClsGrid() {" +

"        $find(\"<%= PageRadAjaxManager.ClientID %>\").ajaxRequest(\"RefreshCls\");" +



"    function changeClassesDisplay(bChecked) {" +

"        var wbtAjaxArgs = 'DisplayCompletedClasses||' + bChecked;" +

"        var ajaxManager = $find(\"<%= PageRadAjaxManager.ClientID %>\");" +

"        ajaxManager.ajaxRequest(wbtAjaxArgs);" +



"    function editSession() {" +

"        var grid = $find(\"<%= SessionRadGrid.ClientID %>\");" +

"        var gridSelectedItems = grid.get_selectedItems();" +

"        if (gridSelectedItems.length == 0)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgSessionCheckOneSelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else if (gridSelectedItems.length > 1)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgSessionCheckOneOnlySelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else if (gridSelectedItems[0].getDataKeyValue('SCHSTAT') == 'D')" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgSessionAlreadyComplete\", oUser.Subdomain) %>', '', 300, 100);" +

"        else {" +

"            var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"            oWnd.show();" +

"            oWnd.setSize(850, 560);" +

"            oWnd.center();" +

"            if (gridSelectedItems[0].getDataKeyValue('SCHED_ID') != '0')" +

"                oWnd.set_title('<%= oLoc.GetStringJS(\"LblEditUserSession\", oUser.Subdomain) %>');" +

"            else" +

"                oWnd.set_title('<%= oLoc.GetStringJS(\"LblAddUserSession\", oUser.Subdomain) %>');" +

"            oWnd.setUrl('user_crsclsedit.aspx?target=userses&userid=<%= nUserId %>&id=' +" +

"                gridSelectedItems[0].getDataKeyValue('COURSE_ID'));" +

"            oWnd.add_close(OnClose);" +




"    function dropSession() {" +

"        var grid = $find(\"<%= SessionRadGrid.ClientID %>\");" +

"        var gridSelectedItems = grid.get_selectedItems();" +

"        if (gridSelectedItems.length == 0)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgSessionCheckOneSelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else if (gridSelectedItems.length > 1)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgSessionCheckOneOnlySelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else if (gridSelectedItems[0].getDataKeyValue('SCHSTAT') == 'D')" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgSessionAlreadyComplete\", oUser.Subdomain) %>', '', 300, 100);" +

"        else if (gridSelectedItems[0].getDataKeyValue('ESTATUS') == 'N')" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgSessionNoBookingExist\", oUser.Subdomain) %>', '', 300, 100);" +

"        else {" +

"            var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"            oWnd.show();" +

"            oWnd.setSize(640, 220);" +

"            oWnd.center();" +

"            oWnd.set_title('<%= oLoc.GetStringJS(\"LblDropUserSession\", oUser.Subdomain) %>');" +

"            oWnd.setUrl('user_sescancel.aspx?userid=<%= nUserId %>&courseid=' +" +

"                gridSelectedItems[0].getDataKeyValue('COURSE_ID') +" +

"                '&schedid=' +" +

"                gridSelectedItems[0].getDataKeyValue('SCHED_ID'));" +

"            oWnd.add_close(OnClose);" +




"    function RefreshSessionGrid() {" +

"        $find(\"<%= PageRadAjaxManager.ClientID %>\").ajaxRequest(\"RefreshSession\");" +



"    function addRole() {" +

"        var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"        oWnd.show();" +

"        oWnd.setSize(850, 550);" +

"        oWnd.center();" +

"        oWnd.set_title('<%= oLoc.GetStringJS(\"LblAddUserRole\", oUser.Subdomain) %>');" +

"        oWnd.setUrl('../search/roles.aspx?userid=<%= nUserId %>');" +

"        oWnd.add_close(OnClose);" +



"    function dropRole() {" +

"        var grid = $find(\"<%= RoleRadGrid.ClientID %>\");" +

"        var gridSelectedItems = grid.get_selectedItems();" +

"        if (gridSelectedItems.length == 0)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgRoleCheckOneSelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else {" +

"            var list = getSelectedElementList(gridSelectedItems, 'ROLE_ID', 'ORG_ID');" +

"            var wbtAjaxArgs = 'DropRole||' + list;" +

"            var ajaxManager = $find(\"<%= PageRadAjaxManager.ClientID %>\");" +

"            ajaxManager.ajaxRequest(wbtAjaxArgs);" +




"    function editRole() {" +

"        var grid = $find(\"<%= RoleRadGrid.ClientID %>\");" +

"        var gridSelectedItems = grid.get_selectedItems();" +

"        if (gridSelectedItems.length == 0)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgRoleCheckOneSelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else if (gridSelectedItems.length > 1)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgRoleCheckOneOnlySelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else {" +

"            var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"            oWnd.show();" +

"            oWnd.setSize(850, 550);" +

"            oWnd.center();" +

"            oWnd.set_title('<%= oLoc.GetStringJS(\"LblEditUserRole\", oUser.Subdomain) %>');" +

"            oWnd.setUrl('user_rolepermedit.aspx?userid=<%= nUserId %>&roleid=' +" +

"                gridSelectedItems[0].getDataKeyValue('ROLE_ID') +" +

"                '&orgid=' +" +

"                gridSelectedItems[0].getDataKeyValue('ORG_ID'));" +

"            oWnd.add_close(OnClose);" +




"    function RefreshRoleGrid() {" +

"        $find(\"<%= PageRadAjaxManager.ClientID %>\").ajaxRequest(\"RefreshRole\");" +



"    function addPerm() {" +

"        var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"        oWnd.show();" +

"        oWnd.setSize(850, 550);" +

"        oWnd.center();" +

"        oWnd.set_title('<%= oLoc.GetStringJS(\"LblAddUserAdditionalPermission\", oUser.Subdomain) %>');" +

"        oWnd.setUrl('../search/perms.aspx?userid=<%= nUserId %>');" +

"        oWnd.add_close(OnClose);" +



"    function dropPerm() {" +

"        var grid = $find(\"<%= PermRadGrid.ClientID %>\");" +

"        var gridSelectedItems = grid.get_selectedItems();" +

"        if (gridSelectedItems.length == 0)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgPermCheckOneSelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else {" +

"            var list = getSelectedElementList(gridSelectedItems, 'PERM_ID', 'ORG_ID');" +

"            var wbtAjaxArgs = 'DropPerm||' + list;" +

"            var ajaxManager = $find(\"<%= PageRadAjaxManager.ClientID %>\");" +

"            ajaxManager.ajaxRequest(wbtAjaxArgs);" +




"    function editPerm() {" +

"        var grid = $find(\"<%= PermRadGrid.ClientID %>\");" +

"        var gridSelectedItems = grid.get_selectedItems();" +

"        if (gridSelectedItems.length == 0)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgPermCheckOneSelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else if (gridSelectedItems.length > 1)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgPermCheckOneOnlySelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else {" +

"            var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"            oWnd.show();" +

"            oWnd.setSize(850, 550);" +

"            oWnd.center();" +

"            oWnd.set_title('<%= oLoc.GetStringJS(\"LblEditUserPerm\", oUser.Subdomain) %>');" +

"            oWnd.setUrl('user_rolepermedit.aspx?userid=<%= nUserId %>&permid=' +" +

"                gridSelectedItems[0].getDataKeyValue('PERM_ID') +" +

"                '&orgid=' +" +

"                gridSelectedItems[0].getDataKeyValue('ORG_ID'));" +

"            oWnd.add_close(OnClose);" +




"    function RefreshPermGrid() {" +

"        $find(\"<%= PageRadAjaxManager.ClientID %>\").ajaxRequest(\"RefreshPerm\");" +



"    function addManagedUser() {" +

"        var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"        oWnd.show();" +

"        oWnd.setSize(800, 500);" +

"        oWnd.center();" +

"        oWnd.set_title('<%= oLoc.GetStringJS(\"LblAddUserManagedUser\", oUser.Subdomain) %>');" +

"        oWnd.setUrl('../search/users.aspx?action=addmanaged&userid=<%= nUserId %>');" +

"        oWnd.add_close(OnClose);" +



"    function dropManagedUser() {" +

"        var grid = $find(\"<%= ManagedUserRadGrid.ClientID %>\");" +

"        var gridSelectedItems = grid.get_selectedItems();" +

"        if (gridSelectedItems.length == 0)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgUserCheckOneSelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else {" +

"            var list = getSelectedElementList(gridSelectedItems, 'ID');" +

"            var wbtAjaxArgs = 'DropManagedUser||' + list;" +

"            var ajaxManager = $find(\"<%= PageRadAjaxManager.ClientID %>\");" +

"            ajaxManager.ajaxRequest(wbtAjaxArgs);" +




"    function RefreshManagedUserGrid() {" +

"        $find(\"<%= PageRadAjaxManager.ClientID %>\").ajaxRequest(\"RefreshManagedUser\");" +



"    function addAlternateManagedUser() {" +

"        var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"        oWnd.show();" +

"        oWnd.setSize(800, 500);" +

"        oWnd.center();" +

"        oWnd.set_title('<%= oLoc.GetStringJS(\"LblAddUserAlternateManagedUser\", oUser.Subdomain) %>');" +

"        oWnd.setUrl('../search/users.aspx?action=addalternatemanaged&userid=<%= nUserId %>');" +

"        oWnd.add_close(OnClose);" +



"    function dropAlternateManagedUser() {" +

"        var grid = $find(\"<%= AlternateManagedUserRadGrid.ClientID %>\");" +

"        var gridSelectedItems = grid.get_selectedItems();" +

"        if (gridSelectedItems.length == 0)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgUserCheckOneSelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else {" +

"            var list = getSelectedElementList(gridSelectedItems, 'ID');" +

"            var wbtAjaxArgs = 'DropAlternateManagedUser||' + list;" +

"            var ajaxManager = $find(\"<%= PageRadAjaxManager.ClientID %>\");" +

"            ajaxManager.ajaxRequest(wbtAjaxArgs);" +




"    function RefreshAlternateManagedUserGrid() {" +

"        $find(\"<%= PageRadAjaxManager.ClientID %>\").ajaxRequest(\"RefreshAlternateManagedUser\");" +



"    function addTutorCrs() {" +

"        var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"        oWnd.show();" +

"        oWnd.setSize(850, 560);" +

"        oWnd.center();" +

"        oWnd.set_title('<%= oLoc.GetStringJS(\"LblAddTutorCrs\", oUser.Subdomain) %>');" +

"        oWnd.setUrl('../search/courses.aspx?action=tutor&userid=<%= nUserId %>');" +

"        oWnd.add_close(OnClose);" +



"    function dropTutorCrs() {" +

"        var grid = $find(\"<%= TutorCrsRadGrid.ClientID %>\");" +

"        var gridSelectedItems = grid.get_selectedItems();" +

"        if (gridSelectedItems.length == 0)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgCourseCheckOneSelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else {" +

"            var list = getSelectedElementList(gridSelectedItems, 'ID');" +

"            var wbtAjaxArgs = 'DropTutorCrs||' + list;" +

"            var ajaxManager = $find(\"<%= PageRadAjaxManager.ClientID %>\");" +

"            ajaxManager.ajaxRequest(wbtAjaxArgs);" +




"    function RefreshTutorCrsGrid() {" +

"        $find(\"<%= PageRadAjaxManager.ClientID %>\").ajaxRequest(\"RefreshTutorCrs\");" +



"    function addTutorCls() {" +

"        var oWnd = $find(\"<%= PageRadWindow.ClientID %>\");" +

"        oWnd.show();" +

"        oWnd.setSize(850, 560);" +

"        oWnd.center();" +

"        oWnd.set_title('<%= oLoc.GetStringJS(\"LblAddTutorCls\", oUser.Subdomain) %>');" +

"        oWnd.setUrl('../search/classes.aspx?action=tutor&userid=<%= nUserId %>');" +

"        oWnd.add_close(OnClose);" +



"    function dropTutorCls() {" +

"        var grid = $find(\"<%= TutorClsRadGrid.ClientID %>\");" +

"        var gridSelectedItems = grid.get_selectedItems();" +

"        if (gridSelectedItems.length == 0)" +

"            WbtRadAlert('<%= oLoc.GetStringJS(\"MsgClasseCheckOneSelected\", oUser.Subdomain) %>', '', 300, 100);" +

"        else {" +

"            var list = getSelectedElementList(gridSelectedItems, 'ID');" +

"            var wbtAjaxArgs = 'DropTutorCls||' + list;" +

"            var ajaxManager = $find(\"<%= PageRadAjaxManager.ClientID %>\");" +

"            ajaxManager.ajaxRequest(wbtAjaxArgs);" +




"    function RefreshTutorClsGrid() {" +

"        $find(\"<%= PageRadAjaxManager.ClientID %>\").ajaxRequest(\"RefreshTutorCls\");" +



"    function UnlockAccount() {" +

"        WbtRadConfirm('<%= oLoc.GetStringJS(\"MsgUserUnlockedConfirm\") %>', '', 350, 105, confirmUnlock);" +

"        return false;" +



"    function confirmUnlock(arg) {" +

"        if (arg) {" +

"            var wbtAjaxArgs = 'Unlock';" +

"            var ajaxManager = $find(\"<%= PageRadAjaxManager.ClientID %>\");" +

"            ajaxManager.ajaxRequest(wbtAjaxArgs);" +




"</script>" +

"</telerik:RadScriptBlock>" +

"<telerik:RadWindowManager ID=\"PageRadWindowManager\" runat=\"server\" KeepInScreenBounds=\"true\" VisibleStatusbar=\"false\" VisibleTitlebar=\"false\" Behaviors=\"Close\" VisibleOnPageLoad=\"false\">" +

"    <Windows>" +

"        <telerik:RadWindow ID=\"PageRadWindow\" runat=\"server\" AutoSize=\"false\" KeepInScreenBounds=\"true\" VisibleStatusbar=\"false\" VisibleTitlebar=\"true\" Behaviors=\"Close,Move\" Modal=\"true\" VisibleOnPageLoad=\"false\"/>" +

"    </Windows>" +

"</telerik:RadWindowManager>" +

"<div class=\"MainContainer\">" +

"<div class=\"WinContainerAdmin\">" +

"<div id=\"UserMenu\" class=\"UserAdminMenu\">" +

"    <telerik:RadTabStrip ID=\"RadTabUser\" runat=\"server\" MultiPageID=\"RadMultiPageUser\" OnClientTabSelecting=\"onTabSelecting\" SelectedIndex=\"0\" Orientation=\"VerticalLeft\" Width=\"100%\" Skin=\"\">" +

"        <Tabs>" +

"            <telerik:RadTab runat=\"server\" Value=\"user_info_tab\" TabIndex=\"0\" PageViewID=\"user_info_pv\" CssClass=\"userTab\" SelectedCssClass=\"userTabSelected\" HoveredCssClass=\"userTabHovered\" DisabledCssClass=\"userTabDisabled\"></telerik:RadTab>" +

"            <telerik:RadTab runat=\"server\" Value=\"user_cf_tab\" TabIndex=\"1\" PageViewID=\"user_cf_pv\" CssClass=\"userTab\" SelectedCssClass=\"userTabSelected\" HoveredCssClass=\"userTabHovered\" DisabledCssClass=\"userTabDisabled\"></telerik:RadTab>" +

"            <telerik:RadTab runat=\"server\" Value=\"user_aud_tab\" TabIndex=\"2\" PageViewID=\"user_aud_pv\" CssClass=\"userTab\" SelectedCssClass=\"userTabSelected\" HoveredCssClass=\"userTabHovered\" DisabledCssClass=\"userTabDisabled\"></telerik:RadTab>" +

"            <telerik:RadTab runat=\"server\" Value=\"user_crscls_tab\" TabIndex=\"3\" PageViewID=\"user_crscls_pv\" CssClass=\"userTab\" SelectedCssClass=\"userTabSelected\" HoveredCssClass=\"userTabHovered\" DisabledCssClass=\"userTabDisabled\"></telerik:RadTab>" +

"            <telerik:RadTab runat=\"server\" Value=\"user_roleperm_tab\" TabIndex=\"4\" PageViewID=\"user_roleperm_pv\" CssClass=\"userTab\" SelectedCssClass=\"userTabSelected\" HoveredCssClass=\"userTabHovered\" DisabledCssClass=\"userTabDisabled\"></telerik:RadTab>" +

"            <telerik:RadTab runat=\"server\" Value=\"user_manageduser_tab\" TabIndex=\"5\" PageViewID=\"user_manageduser_pv\" CssClass=\"userTab\" SelectedCssClass=\"userTabSelected\" HoveredCssClass=\"userTabHovered\" DisabledCssClass=\"userTabDisabled\"></telerik:RadTab>" +

"            <telerik:RadTab runat=\"server\" Value=\"user_tutor_tab\" TabIndex=\"6\" PageViewID=\"user_tutor_pv\" CssClass=\"userTab\" SelectedCssClass=\"userTabSelected\" HoveredCssClass=\"userTabHovered\" DisabledCssClass=\"userTabDisabled\"></telerik:RadTab>" +

"        </Tabs>" +

"    </telerik:RadTabStrip>" +

"</div>" +

"<telerik:RadMultiPage ID=\"RadMultiPageUser\" runat=\"server\" SelectedIndex=\"0\">" +

"<telerik:RadPageView runat=\"server\" ID=\"user_info_pv\" TabIndex=\"0\">" +

"<div class=\"UserAdminContent\">" +

"<table class=\"UserAdmin\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" border=\"0\">" +

"<tr class=\"UserAdmin\">" +

"<td class=\"UserAdmin\">" +

"<table class=\"UserAdmin\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\" width=\"100%\" id=\"TableBlocked\" runat=\"server\">" +

"    <tr class=\"UserAdmin\">" +

"        <td class=\"UserAdmin\">" +

"            <asp:Label ID=\"LblBlocked\" runat=\"server\" Text=\"LblBlocked\" CssClass=\"admin bold\" style=\"color: red;\"/>" +

"        </td>" +

"        <td class=\"UserAdmin\">" +

"            <asp:HyperLink ID=\"LblUnblockUser\" CssClass=\"profile\" runat=\"server\" NavigateUrl=\"#\" Text=\"LblUnblockUser\" onclick=\"UnlockAccount();return false;\"/>" +

"        </td>" +

"    </tr>" +

"</table>" +

"<table class=\"UserAdmin\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\">" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblDisabled\" AssociatedControlID=\"ChkUserDisabled\" runat=\"server\" Text=\"LblUserDisabled\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <asp:CheckBox ID=\"ChkUserDisabled\" runat=\"server\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblHierarchyLevel\" runat=\"server\" Text=\"LblHierarchyLevel\" CssClass=\"profile\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblHierarchyLevelValue\" runat=\"server\" Text=\"LblHierarchyLevelValue\" CssClass=\"profile\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblTname\" runat=\"server\" Text=\"LblTname\" CssClass=\"profile\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <telerik:RadComboBox ID=\"cboTname\" runat=\"server\" Width=\"205px\" EnableLoadOnDemand=\"false\" CausesValidation=\"False\" AllowCustomText=\"true\" EnableTextSelection=\"false\" MaxLength=\"50\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblLname\" runat=\"server\" Text=\"LblLname\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <asp:TextBox ID=\"TxtLname\" runat=\"server\" MaxLength=\"120\" CssClass=\"long\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblFname\" runat=\"server\" Text=\"LblFname\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <asp:TextBox ID=\"TxtFname\" runat=\"server\" MaxLength=\"120\" CssClass=\"long\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblLogin\" runat=\"server\" Text=\"LblLogin\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <asp:TextBox ID=\"TxtLogin\" runat=\"server\" MaxLength=\"120\" CssClass=\"long\" onblur=\"changeLogin();\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblPassword\" runat=\"server\" Text=\"LblPassword\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <asp:TextBox ID=\"TxtPassword\" runat=\"server\" TextMode=\"Password\" MaxLength=\"120\" CssClass=\"medium\" onkeyup=\"passwordChanged(0);\"/>&nbsp;&nbsp;<span id=\"PasswordStrenght\" class=\"medium\">...</span>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblPasswordConfirm\" runat=\"server\" Text=\"LblPasswordConfirm\" CssClass=\"profile\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <asp:TextBox ID=\"TxtPasswordConfirm\" runat=\"server\" TextMode=\"Password\" MaxLength=\"120\" CssClass=\"medium\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblChangePasswordNextConn\" AssociatedControlID=\"ChkChangePassword\" runat=\"server\" Text=\"LblChangePasswordNextConn\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <asp:CheckBox ID=\"ChkChangePassword\" runat=\"server\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblEmail\" runat=\"server\" Text=\"LblEmail\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <asp:TextBox ID=\"TxtEmail\" runat=\"server\" MaxLength=\"255\" CssClass=\"long\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\" id=\"TrLanguage\" runat=\"server\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblLanguage\" runat=\"server\" Text=\"LblLanguage\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <telerik:RadComboBox ID=\"cboLanguage\" runat=\"server\" Width=\"205px\" EnableLoadOnDemand=\"false\" CausesValidation=\"False\" AllowCustomText=\"false\" EnableTextSelection=\"false\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblExtid\" runat=\"server\" Text=\"LblExtid\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <asp:TextBox ID=\"TxtExtid\" runat=\"server\" MaxLength=\"255\" CssClass=\"long\" onblur=\"changeExtid();\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblBirthdate\" runat=\"server\" Text=\"LblBirthdate\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <telerik:RadDatePicker ID=\"RadDateBirth\" runat=\"server\" EnableShadows=\"true\" ShowPopupOnFocus=\"true\"" +

"                               ShowAnimation-Type=\"Fade\" ShowAnimation-Duration=\"100\" HideAnimation-Type=\"Fade\" HideAnimation-Duration=\"100\"" +

"                               PopupDirection=\"BottomRight\" EnableScreenBoundaryDetection=\"true\" MinDate=\"01/01/1900\" SkipMinMaxDateValidationOnServer=\"true\">" +

"            <DateInput ReadOnly=\"true\" ReadOnlyStyle-ForeColor=\"Black\" onclick=\"ShowDatePopup('Birth');\"/>" +

"        </telerik:RadDatePicker>" +

"        <asp:Image ID=\"RadDateBirthClear\" runat=\"server\" CssClass=\"pointer\" onclick=\"ClearDate('Birth');return(false);\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblActivationDate\" runat=\"server\" Text=\"LblUserActivationDate\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <telerik:RadDatePicker ID=\"RadDateActivation\" runat=\"server\" EnableShadows=\"true\" ShowPopupOnFocus=\"true\"" +

"                               ShowAnimation-Type=\"Fade\" ShowAnimation-Duration=\"100\" HideAnimation-Type=\"Fade\" HideAnimation-Duration=\"100\"" +

"                               PopupDirection=\"BottomRight\" EnableScreenBoundaryDetection=\"true\" MinDate=\"01/01/1900\" SkipMinMaxDateValidationOnServer=\"true\">" +

"            <DateInput ReadOnly=\"true\" ReadOnlyStyle-ForeColor=\"Black\" onclick=\"ShowDatePopup('Activation');\"/>" +

"        </telerik:RadDatePicker>" +

"        <asp:Image ID=\"RadDateActivationClear\" runat=\"server\" CssClass=\"pointer\" onclick=\"ClearDate('Activation');return(false);\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblExpirationDate\" runat=\"server\" Text=\"LblUserExpirationDate\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <telerik:RadDatePicker ID=\"RadDateExpiration\" runat=\"server\" EnableShadows=\"true\" ShowPopupOnFocus=\"true\"" +

"                               ShowAnimation-Type=\"Fade\" ShowAnimation-Duration=\"100\" HideAnimation-Type=\"Fade\" HideAnimation-Duration=\"100\"" +

"                               PopupDirection=\"BottomRight\" EnableScreenBoundaryDetection=\"true\" MinDate=\"01/01/1900\" SkipMinMaxDateValidationOnServer=\"true\">" +

"            <DateInput ReadOnly=\"true\" ReadOnlyStyle-ForeColor=\"Black\" onclick=\"ShowDatePopup('Expiration');\"/>" +

"        </telerik:RadDatePicker>" +

"        <asp:Image ID=\"RadDateExpirationClear\" runat=\"server\" CssClass=\"pointer\" onclick=\"ClearDate('Expiration');return(false);\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblManager\" runat=\"server\" Text=\"LblManager\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <input type=\"hidden\" id=\"ManagerId\" name=\"ManagerId\" runat=\"server\" value=\"\"/>" +

"        <asp:Label ID=\"LblManagerName\" runat=\"server\" Text=\"\" CssClass=\"admin bold\"/>&nbsp;" +

"        <asp:Image ID=\"ImgSelectManager\" runat=\"server\" CssClass=\"pointer\" onclick=\"selectManager();return(false);\"/>" +

"        <asp:Image ID=\"ImgDeleteManager\" runat=\"server\" CssClass=\"pointer\" onclick=\"deleteManager();return(false);\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblAlternateManager\" runat=\"server\" Text=\"LblAlternateManager\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <input type=\"hidden\" id=\"AlternateManagerId\" name=\"AlternateManagerId\" runat=\"server\" value=\"\"/>" +

"        <asp:Label ID=\"LblAlternateManagerName\" runat=\"server\" Text=\"\" CssClass=\"admin bold\"/>&nbsp;" +

"        <asp:Image ID=\"ImgSelectAlternateManager\" runat=\"server\" CssClass=\"pointer\" onclick=\"selectAlternateManager();return(false);\"/>" +

"        <asp:Image ID=\"ImgDeleteAlternateManager\" runat=\"server\" CssClass=\"pointer\" onclick=\"deleteAlternateManager();return(false);\"/>" +

"    </td>" +

"</tr>" +

"<tr>" +

"    <td>&nbsp;</td><td>&nbsp;</td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblHourlyCost\" runat=\"server\" Text=\"LblHourlyCost\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <telerik:RadNumericTextBox ID=\"TxtHourlyCost\" runat=\"server\" ShowSpinButtons=\"false\" MinValue=\"0\" Width=\"100px\" AllowOutOfRangeAutoCorrect=\"true\" Type=\"Number\">" +

"            <IncrementSettings InterceptArrowKeys=\"false\" InterceptMouseWheel=\"false\"/>" +

"            <NumberFormat DecimalDigits=\"2\" GroupSeparator=\"\"/>" +

"        </telerik:RadNumericTextBox>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblAddress1\" runat=\"server\" Text=\"LblAddress1\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <asp:TextBox ID=\"TxtAddress1\" runat=\"server\" MaxLength=\"255\" CssClass=\"long\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblAddress2\" runat=\"server\" Text=\"LblAddress2\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <asp:TextBox ID=\"TxtAddress2\" runat=\"server\" MaxLength=\"255\" CssClass=\"long\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblZipCode\" runat=\"server\" Text=\"LblZipCode\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <asp:TextBox ID=\"TxtZipCode\" runat=\"server\" MaxLength=\"255\" CssClass=\"long\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblCity\" runat=\"server\" Text=\"LblCity\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <asp:TextBox ID=\"TxtCity\" runat=\"server\" MaxLength=\"255\" CssClass=\"long\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblCountry\" runat=\"server\" Text=\"LblCountry\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <asp:TextBox ID=\"TxtCountry\" runat=\"server\" MaxLength=\"255\" CssClass=\"long\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblPhone\" runat=\"server\" Text=\"LblPhone\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <asp:TextBox ID=\"TxtPhone\" runat=\"server\" MaxLength=\"255\" CssClass=\"long\"/>" +

"    </td>" +

"</tr>" +

"<tr class=\"UserAdmin\">" +

"    <td class=\"UserAdmin\">" +

"        <asp:Label ID=\"LblCellphone\" runat=\"server\" Text=\"LblCellphone\" CssClass=\"admin\"/>" +

"    </td>" +

"    <td class=\"UserAdmin\">" +

"        <asp:TextBox ID=\"TxtCellphone\" runat=\"server\" MaxLength=\"255\" CssClass=\"long\"/>" +

"    </td>" +

"</tr>" +

"</table>" +

"</td>" +

"<td class=\"UserAdminImage\" width=\"26%\" style=\"text-align: center; vertical-align: top;\">" +

"    <br/>" +

"    <asp:Image ID=\"ImgProfile\" runat=\"server\" CssClass=\"Profile\"/>" +

"</td>" +

"</tr>" +

"</table>" +

"</div>" +

"</telerik:RadPageView>" +

"<telerik:RadPageView runat=\"server\" ID=\"user_cf_pv\" TabIndex=\"1\">" +

"    <div class=\"UserAdminContent\">" +

"        <telerik:RadTabStrip ID=\"RadTabCustomFields\" runat=\"server\" MultiPageID=\"RadMultiPageCustomFields\" SelectedIndex=\"0\">" +

"            <Tabs>" +

"                <telerik:RadTab runat=\"server\" Value=\"user_cf_standard_tab\" TabIndex=\"0\" PageViewID=\"user_cf_standard_pv\"></telerik:RadTab>" +

"                <telerik:RadTab runat=\"server\" Value=\"user_cf_additional_tab\" TabIndex=\"1\" PageViewID=\"user_cf_additional_pv\"></telerik:RadTab>" +

"            </Tabs>" +

"        </telerik:RadTabStrip>" +

"        <telerik:RadMultiPage ID=\"RadMultiPageCustomFields\" runat=\"server\" SelectedIndex=\"0\">" +

"            <telerik:RadPageView runat=\"server\" ID=\"user_cf_standard_pv\" TabIndex=\"0\">" +

"                <div id=\"UserStandardCF\" class=\"UserAdminCustomField\">" +

"                    <br/>" +

"                    <table class=\"UserAdmin\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\">" +

"                        <tr class=\"UserAdmin\">" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:Label ID=\"LblUserCustomField1\" runat=\"server\" Text=\"LblUserCustomField1\" CssClass=\"admin\"/>" +

"                            </td>" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:TextBox ID=\"TxtUserCustomField1\" runat=\"server\" MaxLength=\"255\" CssClass=\"longplus2\"/>" +

"                            </td>" +

"                        </tr>" +

"                        <tr class=\"UserAdmin\">" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:Label ID=\"LblUserCustomField2\" runat=\"server\" Text=\"LblUserCustomField2\" CssClass=\"admin\"/>" +

"                            </td>" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:TextBox ID=\"TxtUserCustomField2\" runat=\"server\" MaxLength=\"255\" CssClass=\"longplus2\"/>" +

"                            </td>" +

"                        </tr>" +

"                        <tr class=\"UserAdmin\">" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:Label ID=\"LblUserCustomField3\" runat=\"server\" Text=\"LblUserCustomField3\" CssClass=\"admin\"/>" +

"                            </td>" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:TextBox ID=\"TxtUserCustomField3\" runat=\"server\" MaxLength=\"255\" CssClass=\"longplus2\"/>" +

"                            </td>" +

"                        </tr>" +

"                        <tr class=\"UserAdmin\">" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:Label ID=\"LblUserCustomField4\" runat=\"server\" Text=\"LblUserCustomField4\" CssClass=\"admin\"/>" +

"                            </td>" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:TextBox ID=\"TxtUserCustomField4\" runat=\"server\" MaxLength=\"255\" CssClass=\"longplus2\"/>" +

"                            </td>" +

"                        </tr>" +

"                        <tr class=\"UserAdmin\">" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:Label ID=\"LblUserCustomField5\" runat=\"server\" Text=\"LblUserCustomField5\" CssClass=\"admin\"/>" +

"                            </td>" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:TextBox ID=\"TxtUserCustomField5\" runat=\"server\" MaxLength=\"255\" CssClass=\"longplus2\"/>" +

"                            </td>" +

"                        </tr>" +

"                        <tr class=\"UserAdmin\">" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:Label ID=\"LblUserCustomField6\" runat=\"server\" Text=\"LblUserCustomField6\" CssClass=\"admin\"/>" +

"                            </td>" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:TextBox ID=\"TxtUserCustomField6\" runat=\"server\" MaxLength=\"255\" CssClass=\"longplus2\"/>" +

"                            </td>" +

"                        </tr>" +

"                        <tr class=\"UserAdmin\">" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:Label ID=\"LblUserCustomField7\" runat=\"server\" Text=\"LblUserCustomField7\" CssClass=\"admin\"/>" +

"                            </td>" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:TextBox ID=\"TxtUserCustomField7\" runat=\"server\" MaxLength=\"255\" CssClass=\"longplus2\"/>" +

"                            </td>" +

"                        </tr>" +

"                        <tr class=\"UserAdmin\">" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:Label ID=\"LblUserCustomField8\" runat=\"server\" Text=\"LblUserCustomField8\" CssClass=\"admin\"/>" +

"                            </td>" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:TextBox ID=\"TxtUserCustomField8\" runat=\"server\" MaxLength=\"255\" CssClass=\"longplus2\"/>" +

"                            </td>" +

"                        </tr>" +

"                        <tr class=\"UserAdmin\">" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:Label ID=\"LblUserCustomField9\" runat=\"server\" Text=\"LblUserCustomField9\" CssClass=\"admin\"/>" +

"                            </td>" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:TextBox ID=\"TxtUserCustomField9\" runat=\"server\" MaxLength=\"255\" CssClass=\"longplus2\"/>" +

"                            </td>" +

"                        </tr>" +

"                        <tr class=\"UserAdmin\">" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:Label ID=\"LblUserCustomField10\" runat=\"server\" Text=\"LblUserCustomField10\" CssClass=\"admin\"/>" +

"                            </td>" +

"                            <td class=\"UserAdmin\">" +

"                                <asp:TextBox ID=\"TxtUserCustomField10\" runat=\"server\" MaxLength=\"255\" CssClass=\"longplus2\"/>" +

"                            </td>" +

"                        </tr>" +

"                    </table>" +

"                </div>" +

"            </telerik:RadPageView>" +

"            <telerik:RadPageView runat=\"server\" ID=\"user_cf_additional_pv\" TabIndex=\"1\">" +

"                <div id=\"UserAdditionalCF\" class=\"UserAdminCustomField\">" +


"                </div>" +

"            </telerik:RadPageView>" +

"        </telerik:RadMultiPage>" +

"    </div>" +

"</telerik:RadPageView>" +

"<telerik:RadPageView runat=\"server\" ID=\"user_aud_pv\" TabIndex=\"2\">" +

"    <div class=\"UserAdminContent\">" +

"        <div id=\"UserAudGrid\" class=\"UserAdminAudGrid\">" +

"            <ul class=\"toolBar\">" +

"                <li class=\"toolItem\">" +

"                    <asp:HyperLink ID=\"AudAdd\" runat=\"server\" NavigateUrl=\"#\" onClick=\"addAud();return(false);\">" +

"                        <span class=\"glyphicons add\"></span></asp:HyperLink>" +

"                </li>" +

"                <li class=\"toolItem\">" +

"                    <asp:HyperLink ID=\"AudDrop\" runat=\"server\" NavigateUrl=\"#\" onClick=\"dropAud();return(false);\">" +

"                        <span class=\"glyphicons remove\"></span></asp:HyperLink>" +

"                </li>" +

"            </ul>" +

"            <div id=\"AudGrid\" class=\"AudAdminGrid\">" +

"                <telerik:RadGrid ID=\"AudRadGrid\" runat=\"server\" Width=\"100%\" AutoGenerateColumns=\"false\" AllowPaging=\"true\" PageSize=\"15\"" +

"                                 ShowHeader=\"true\" ShowFooter=\"false\" ShowGroupPanel=\"false\" ShowStatusBar=\"false\" OnNeedDataSource=\"AudRadGrid_NeedDataSource\"" +

"                                 AllowMultiRowSelection=\"true\" AllowAutomaticInserts=\"false\" AllowAutomaticDeletes=\"false\" AllowAutomaticUpdates=\"false\" AllowSorting=\"true\" AllowFilteringByColumn=\"false\"" +

"                                 BorderStyle=\"None\" Style=\"overflow: auto;\">" +

"                    <MasterTableView TableLayout=\"Fixed\" Width=\"100%\" ClientDataKeyNames=\"ID\">" +

"                        <Columns>" +

"                            <telerik:GridClientSelectColumn UniqueName=\"CheckboxSelectAud\"/>" +

"                            <telerik:GridBoundColumn UniqueName=\"AudId\" HeaderText=\"\" DataField=\"ID\" Visible=\"false\"/>" +

"                            <telerik:GridBoundColumn UniqueName=\"AudName\" HeaderText=\"AudName\" DataField=\"NAME\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"95%\" ItemStyle-Width=\"95%\" ItemStyle-Wrap=\"false\"/>" +

"                        </Columns>" +

"                        <PagerStyle AlwaysVisible=\"false\" Mode=\"NumericPages\"/>" +

"                    </MasterTableView>" +

"                    <HeaderStyle Font-Bold=\"true\"/>" +

"                    <ClientSettings Selecting-AllowRowSelect=\"true\"/>" +

"                </telerik:RadGrid>" +

"            </div>" +

"        </div>" +

"    </div>" +

"</telerik:RadPageView>" +

"<telerik:RadPageView runat=\"server\" ID=\"user_crscls_pv\" TabIndex=\"3\">" +

"<div class=\"UserAdminContent\">" +

"    <div class=\"spacerBottom\">" +

"        <telerik:RadTabStrip ID=\"RadTabCrsCls\" runat=\"server\" MultiPageID=\"RadMultiPageCrsCls\" SelectedIndex=\"0\">" +

"            <Tabs>" +

"                <telerik:RadTab runat=\"server\" Text=\"Courses\" Value=\"crs\" TabIndex=\"0\" PageViewID=\"RadPageViewCourses\"></telerik:RadTab>" +

"                <telerik:RadTab runat=\"server\" Text=\"Classes\" Value=\"cls\" TabIndex=\"1\" PageViewID=\"RadPageViewClasses\"></telerik:RadTab>" +

"                <telerik:RadTab runat=\"server\" Text=\"Sessions\" Value=\"ses\" TabIndex=\"2\" PageViewID=\"RadPageViewSessions\"></telerik:RadTab>" +

"                <telerik:RadTab runat=\"server\" Text=\"TrainingPlans\" Value=\"plan\" TabIndex=\"3\" PageViewID=\"RadPageViewTrainingPlans\"></telerik:RadTab>" +

"            </Tabs>" +

"        </telerik:RadTabStrip>" +

"    </div>" +

"    <telerik:RadMultiPage ID=\"RadMultiPageCrsCls\" runat=\"server\" SelectedIndex=\"0\">" +

"        <telerik:RadPageView runat=\"server\" ID=\"RadPageViewCourses\" TabIndex=\"0\">" +

"            <div id=\"UserCrsGrid\" class=\"UserAdminCrsClsGrid\">" +

"                <ul class=\"toolBar width_100\">" +

"                    <li class=\"toolItem\">" +

"                        <asp:HyperLink ID=\"CrsAdd\" runat=\"server\" NavigateUrl=\"#\" onClick=\"addCrs();return(false);\">" +

"                            <span class=\"glyphicons add\"></span></asp:HyperLink>" +

"                    </li>" +

"                    <li class=\"toolItem\">" +

"                        <asp:HyperLink ID=\"CrsDrop\" runat=\"server\" NavigateUrl=\"#\" onClick=\"dropCrs();return(false);\">" +

"                            <span class=\"glyphicons remove\"></span></asp:HyperLink>" +

"                    </li>" +

"                    <li class=\"toolItem\">" +

"                        <asp:HyperLink ID=\"CrsEdit\" runat=\"server\" NavigateUrl=\"#\" onClick=\"editCrs();return(false);\">" +

"                            <span class=\"glyphicons edit\"></span></asp:HyperLink>" +

"                    </li>" +

"                    <li class=\"toolItem\">" +

"                        <asp:HyperLink ID=\"CrsReset\" runat=\"server\" NavigateUrl=\"#\" onClick=\"resetCrs();return(false);\">" +

"                            <span class=\"glyphicons reset\"></span></asp:HyperLink>" +

"                    </li>" +

"                    <li class=\"toolItem rightItem textItem\">" +

"                        <asp:CheckBox ID=\"ChkDisplayCompletedCourses\" runat=\"server\" OnClick=\"changeCoursesDisplay(this.checked);\"/>" +

"                        <asp:Label ID=\"LblDisplayCompletedCourses\" runat=\"server\" AssociatedControlID=\"ChkDisplayCompletedCourses\" Text=\"LblDisplayCompletedCourses\" CssClass=\"admin\"/>" +

"                    </li>" +

"                </ul>" +

"                <div id=\"CrsGrid\" class=\"CrsClsAdminGrid\">" +

"                    <telerik:RadGrid ID=\"CrsRadGrid\" runat=\"server\" Width=\"100%\" AutoGenerateColumns=\"false\" AllowPaging=\"true\" PageSize=\"14\"" +

"                                     ShowHeader=\"true\" ShowFooter=\"false\" ShowGroupPanel=\"false\" ShowStatusBar=\"false\" OnNeedDataSource=\"CrsRadGrid_NeedDataSource\"" +

"                                     AllowMultiRowSelection=\"true\" AllowAutomaticInserts=\"false\" AllowAutomaticDeletes=\"false\" AllowAutomaticUpdates=\"false\" AllowSorting=\"true\" AllowFilteringByColumn=\"false\"" +

"                                     BorderStyle=\"None\" Style=\"overflow: auto;\">" +

"                        <MasterTableView TableLayout=\"Fixed\" Width=\"100%\" ClientDataKeyNames=\"CRS_ID\">" +

"                            <Columns>" +

"                                <telerik:GridClientSelectColumn UniqueName=\"CheckboxSelectCrs\"/>" +

"                                <telerik:GridBoundColumn UniqueName=\"CrsId\" HeaderText=\"\" DataField=\"CRS_ID\" Visible=\"false\"/>" +

"                                <telerik:GridTemplateColumn UniqueName=\"CrsIlt\" HeaderText=\"\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"3%\" ItemStyle-Width=\"3%\">" +

"                                    <ItemTemplate>" +

"                                        <%# bIlt && int.Parse(Eval(\"CRSTYPE\").ToString()) == 2 ? \"<img title=\"\" + oLoc.GetString(\"LblInstructorLedTraining\", oUser.Subdomain) + \"\" src=\"../img/\" + Session[\"WBTImgPath\"] + \"training/ilt.png\" />\" : \"\" %>" +

"                                    </ItemTemplate>" +

"                                </telerik:GridTemplateColumn>" +

"                                <telerik:GridTemplateColumn UniqueName=\"CrsCls\" HeaderText=\"\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"3%\" ItemStyle-Width=\"3%\">" +

"                                    <ItemTemplate>" +

"                                        <%# int.Parse(Eval(\"IN_CLASS\").ToString()) == 1 ? \"<img title=\"\" + oLoc.GetString(\"LblCourseInClass\", oUser.Subdomain) + \"\" src=\"../img/\" + Session[\"WBTImgPath\"] + \"training/inclass.png\" />\" : \"\" %>" +

"                                    </ItemTemplate>" +

"                                </telerik:GridTemplateColumn>" +

"                                <telerik:GridBoundColumn UniqueName=\"CrsName\" HeaderText=\"CrsName\" DataField=\"CRS_NAME\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"44%\" ItemStyle-Width=\"44%\" ItemStyle-Wrap=\"false\"/>" +

"                                <telerik:GridDateTimeColumn UniqueName=\"AfterDt\" HeaderText=\"LblAfterDate\" DataField=\"AFTERDT\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"15%\" HeaderStyle-HorizontalAlign=\"Right\" ItemStyle-Width=\"15%\" ItemStyle-HorizontalAlign=\"Right\"/>" +

"                                <telerik:GridDateTimeColumn UniqueName=\"TargetDt\" HeaderText=\"LblTargetDate\" DataField=\"TARGETDT\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"15%\" HeaderStyle-HorizontalAlign=\"Right\" ItemStyle-Width=\"15%\" ItemStyle-HorizontalAlign=\"Right\"/>" +

"                                <telerik:GridDateTimeColumn UniqueName=\"CutoffDt\" HeaderText=\"LblCutoffDate\" DataField=\"CUTOFFDT\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"15%\" HeaderStyle-HorizontalAlign=\"Right\" ItemStyle-Width=\"15%\" ItemStyle-HorizontalAlign=\"Right\"/>" +

"                            </Columns>" +

"                            <PagerStyle AlwaysVisible=\"false\" Mode=\"NumericPages\"/>" +

"                        </MasterTableView>" +

"                        <HeaderStyle Font-Bold=\"true\"/>" +

"                        <ClientSettings Selecting-AllowRowSelect=\"true\">" +

"                            <ClientEvents OnRowDblClick=\"editCrs\"/>" +

"                        </ClientSettings>" +

"                    </telerik:RadGrid>" +

"                </div>" +

"            </div>" +

"        </telerik:RadPageView>" +

"        <telerik:RadPageView runat=\"server\" ID=\"RadPageViewClasses\" TabIndex=\"1\">" +

"            <div id=\"UserClsGrid\" class=\"UserAdminCrsClsGrid\">" +

"                <ul class=\"toolBar width_100\">" +

"                    <li class=\"toolItem\">" +

"                        <asp:HyperLink ID=\"ClsAdd\" runat=\"server\" NavigateUrl=\"#\" onClick=\"addCls();return(false);\">" +

"                            <span class=\"glyphicons add\"></span></asp:HyperLink>" +

"                    </li>" +

"                    <li class=\"toolItem\">" +

"                        <asp:HyperLink ID=\"ClsDrop\" runat=\"server\" NavigateUrl=\"#\" onClick=\"dropCls();return(false);\">" +

"                            <span class=\"glyphicons remove\"></span></asp:HyperLink>" +

"                    </li>" +

"                    <li class=\"toolItem\">" +

"                        <asp:HyperLink ID=\"ClsEdit\" runat=\"server\" NavigateUrl=\"#\" onClick=\"editCls();return(false);\">" +

"                            <span class=\"glyphicons edit\"></span></asp:HyperLink>" +

"                    </li>" +

"                    <li class=\"toolItem\">" +

"                        <asp:HyperLink ID=\"ClsReset\" runat=\"server\" NavigateUrl=\"#\" onClick=\"resetCls();return(false);\">" +

"                            <span class=\"glyphicons reset\"></span></asp:HyperLink>" +

"                    </li>" +

"                    <li class=\"toolItem rightItem textItem\">" +

"                        <asp:CheckBox ID=\"ChkDisplayCompletedClasses\" runat=\"server\" OnClick=\"changeClassesDisplay(this.checked);\"/>" +

"                        <asp:Label ID=\"LblDisplayCompletedClasses\" runat=\"server\" AssociatedControlID=\"ChkDisplayCompletedClasses\" Text=\"LblDisplayCompletedClasses\" CssClass=\"admin\"/>" +

"                    </li>" +

"                </ul>" +

"                <div id=\"ClsGrid\" class=\"CrsClsAdminGrid\">" +

"                    <telerik:RadGrid ID=\"ClsRadGrid\" runat=\"server\" Width=\"100%\" AutoGenerateColumns=\"false\" AllowPaging=\"true\" PageSize=\"14\"" +

"                                     ShowHeader=\"true\" ShowFooter=\"false\" ShowGroupPanel=\"false\" ShowStatusBar=\"false\" OnNeedDataSource=\"ClsRadGrid_NeedDataSource\"" +

"                                     AllowMultiRowSelection=\"true\" AllowAutomaticInserts=\"false\" AllowAutomaticDeletes=\"false\" AllowAutomaticUpdates=\"false\" AllowSorting=\"true\" AllowFilteringByColumn=\"false\"" +

"                                     BorderStyle=\"None\" Style=\"overflow: auto;\">" +

"                        <MasterTableView TableLayout=\"Fixed\" Width=\"100%\" ClientDataKeyNames=\"CLS_ID\">" +

"                            <Columns>" +

"                                <telerik:GridClientSelectColumn UniqueName=\"CheckboxSelectCls\"/>" +

"                                <telerik:GridBoundColumn UniqueName=\"ClsId\" HeaderText=\"\" DataField=\"CLS_ID\" Visible=\"false\"/>" +

"                                <telerik:GridBoundColumn UniqueName=\"ClsName\" HeaderText=\"ClsName\" DataField=\"CLS_NAME\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"50%\" ItemStyle-Width=\"50%\" ItemStyle-Wrap=\"false\"/>" +

"                                <telerik:GridDateTimeColumn UniqueName=\"AfterDt\" HeaderText=\"LblAfterDate\" DataField=\"AFTERDT\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"15%\" HeaderStyle-HorizontalAlign=\"Right\" ItemStyle-Width=\"15%\" ItemStyle-HorizontalAlign=\"Right\"/>" +

"                                <telerik:GridDateTimeColumn UniqueName=\"TargetDt\" HeaderText=\"LblTargetDate\" DataField=\"TARGETDT\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"15%\" HeaderStyle-HorizontalAlign=\"Right\" ItemStyle-Width=\"15%\" ItemStyle-HorizontalAlign=\"Right\"/>" +

"                                <telerik:GridDateTimeColumn UniqueName=\"CutoffDt\" HeaderText=\"LblCutoffDate\" DataField=\"CUTOFFDT\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"15%\" HeaderStyle-HorizontalAlign=\"Right\" ItemStyle-Width=\"15%\" ItemStyle-HorizontalAlign=\"Right\"/>" +

"                            </Columns>" +

"                            <PagerStyle AlwaysVisible=\"false\" Mode=\"NumericPages\"/>" +

"                        </MasterTableView>" +

"                        <HeaderStyle Font-Bold=\"true\"/>" +

"                        <ClientSettings Selecting-AllowRowSelect=\"true\">" +

"                            <ClientEvents OnRowDblClick=\"editCls\"/>" +

"                        </ClientSettings>" +

"                    </telerik:RadGrid>" +

"                </div>" +

"            </div>" +

"        </telerik:RadPageView>" +

"        <telerik:RadPageView runat=\"server\" ID=\"RadPageViewSessions\" TabIndex=\"2\">" +

"            <div id=\"UserSesGrid\" class=\"UserAdminCrsClsGrid\">" +

"                <ul class=\"toolBar\">" +

"                    <li class=\"toolItem\">" +

"                        <asp:HyperLink ID=\"SessionAdd\" runat=\"server\" NavigateUrl=\"#\" onClick=\"editSession();return(false);\">" +

"                            <span class=\"glyphicons add\"></span></asp:HyperLink>" +

"                    </li>" +

"                    <li class=\"toolItem\">" +

"                        <asp:HyperLink ID=\"SessionDrop\" runat=\"server\" NavigateUrl=\"#\" onClick=\"dropSession();return(false);\">" +

"                            <span class=\"glyphicons remove\"></span></asp:HyperLink>" +

"                    </li>" +

"                    <li class=\"toolItem\">" +

"                        <asp:HyperLink ID=\"SessionEdit\" runat=\"server\" NavigateUrl=\"#\" onClick=\"editSession();return(false);\">" +

"                            <span class=\"glyphicons edit\"></span></asp:HyperLink>" +

"                    </li>" +

"                </ul>" +

"                <div id=\"SesGrid\" class=\"CrsClsAdminGrid\">" +

"                    <telerik:RadGrid ID=\"SessionRadGrid\" runat=\"server\" Width=\"100%\" AutoGenerateColumns=\"false\" AllowPaging=\"true\" PageSize=\"14\"" +

"                                     ShowHeader=\"true\" ShowFooter=\"false\" ShowGroupPanel=\"false\" ShowStatusBar=\"false\" OnNeedDataSource=\"SessionRadGrid_NeedDataSource\"" +

"                                     AllowMultiRowSelection=\"true\" AllowAutomaticInserts=\"false\" AllowAutomaticDeletes=\"false\" AllowAutomaticUpdates=\"false\" AllowSorting=\"true\" AllowFilteringByColumn=\"false\"" +

"                                     BorderStyle=\"None\" Style=\"overflow: auto;\">" +

"                        <MasterTableView TableLayout=\"Fixed\" Width=\"100%\" ClientDataKeyNames=\"COURSE_ID,SCHED_ID,SCHSTAT,ESTATUS\">" +

"                            <Columns>" +

"                                <telerik:GridClientSelectColumn UniqueName=\"CheckboxSelectSession\"/>" +

"                                <telerik:GridTemplateColumn UniqueName=\"SessionName\" HeaderText=\"SessionName\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"46%\" ItemStyle-Width=\"46%\">" +

"                                    <ItemTemplate>" +

"                                        <%#GetName(Eval(\"NAME\").ToString(), Eval(\"EXTID\").ToString()) %>" +

"                                    </ItemTemplate>" +

"                                </telerik:GridTemplateColumn>" +

"                                <telerik:GridTemplateColumn UniqueName=\"SessionDate\" HeaderText=\"SessionDate\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"17%\" ItemStyle-Width=\"17%\">" +

"                                    <ItemTemplate>" +

"                                        <%#GetDates(Eval(\"SCHSTART\").ToString(), Eval(\"SCHEND\").ToString()) %>" +

"                                    </ItemTemplate>" +

"                                </telerik:GridTemplateColumn>" +

"                                <telerik:GridDateTimeColumn UniqueName=\"BookingDate\" HeaderText=\"BookingDate\" DataField=\"RDATE\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"15%\" HeaderStyle-HorizontalAlign=\"Right\" ItemStyle-Width=\"15%\" ItemStyle-HorizontalAlign=\"Right\"/>" +

"                                <telerik:GridTemplateColumn UniqueName=\"BookingStatus\" HeaderText=\"BookingStatus\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"17%\" ItemStyle-Width=\"17%\">" +

"                                    <ItemTemplate>" +

"                                        <%#GetBookingStatus(Eval(\"ESTATUS\").ToString()) %>" +

"                                    </ItemTemplate>" +

"                                </telerik:GridTemplateColumn>" +

"                            </Columns>" +

"                            <PagerStyle AlwaysVisible=\"false\" Mode=\"NumericPages\"/>" +

"                        </MasterTableView>" +

"                        <HeaderStyle Font-Bold=\"true\"/>" +

"                        <ClientSettings Selecting-AllowRowSelect=\"true\">" +

"                            <ClientEvents OnRowDblClick=\"editSession\"/>" +

"                        </ClientSettings>" +

"                    </telerik:RadGrid>" +

"                </div>" +

"            </div>" +

"        </telerik:RadPageView>" +

"        <telerik:RadPageView runat=\"server\" ID=\"RadPageViewTrainingPlans\" TabIndex=\"3\">" +

"            <div id=\"UserPlanGrid\" class=\"UserAdminCrsClsGrid\">" +

"                <div id=\"PlanGrid\" class=\"CrsClsAdminGrid\">" +

"                    <telerik:RadGrid ID=\"TrainingPlanRadGrid\" runat=\"server\" Width=\"100%\" AutoGenerateColumns=\"false\" AllowPaging=\"true\" PageSize=\"18\"" +

"                                     ShowHeader=\"true\" ShowFooter=\"false\" ShowGroupPanel=\"false\" ShowStatusBar=\"false\" OnNeedDataSource=\"TrainingPlanRadGrid_NeedDataSource\"" +

"                                     AllowMultiRowSelection=\"true\" AllowAutomaticInserts=\"false\" AllowAutomaticDeletes=\"false\" AllowAutomaticUpdates=\"false\" AllowSorting=\"true\" AllowFilteringByColumn=\"false\"" +

"                                     BorderStyle=\"None\" Style=\"overflow: auto;\">" +

"                        <MasterTableView TableLayout=\"Fixed\" Width=\"100%\" ClientDataKeyNames=\"REQUEST_ID\">" +

"                            <Columns>" +

"                                <telerik:GridBoundColumn UniqueName=\"RequestId\" HeaderText=\"\" DataField=\"REQUEST_ID\" Visible=\"false\"/>" +

"                                <telerik:GridBoundColumn UniqueName=\"RequestCourse\" DataField=\"COURSE_NAME\" HeaderText=\"RequestCourse\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"45%\" ItemStyle-Width=\"45%\" ItemStyle-Wrap=\"false\"/>" +

"                                <telerik:GridTemplateColumn UniqueName=\"RequestStatus\" HeaderText=\"RequestStatus\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"20%\" ItemStyle-Width=\"20%\" ItemStyle-Wrap=\"false\">" +

"                                    <ItemTemplate>" +

"                                        <%# GetRequestStatus(Eval(\"REQUEST_STATUS\").ToString()) %>" +

"                                    </ItemTemplate>" +

"                                </telerik:GridTemplateColumn>" +

"                                <telerik:GridBoundColumn UniqueName=\"RequestAdmin\" DataField=\"ADMIN_NAME\" HeaderText=\"RequestAdmin\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"20%\" ItemStyle-Width=\"20%\" ItemStyle-Wrap=\"false\"/>" +

"                                <telerik:GridDateTimeColumn UniqueName=\"RequestDate\" DataField=\"REQUEST_DATE\" HeaderText=\"RequestDate\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"15%\" HeaderStyle-HorizontalAlign=\"Right\" ItemStyle-Width=\"15%\" ItemStyle-HorizontalAlign=\"Right\"/>" +

"                            </Columns>" +

"                            <PagerStyle AlwaysVisible=\"false\" Mode=\"NumericPages\"/>" +

"                        </MasterTableView>" +

"                        <HeaderStyle Font-Bold=\"true\"/>" +

"                        <ClientSettings Selecting-AllowRowSelect=\"true\">" +

"                            <ClientEvents OnRowDblClick=\"editSession\"/>" +

"                        </ClientSettings>" +

"                    </telerik:RadGrid>" +

"                </div>" +

"            </div>" +

"        </telerik:RadPageView>" +

"    </telerik:RadMultiPage>" +

"</div>" +

"</telerik:RadPageView>" +

"<telerik:RadPageView runat=\"server\" ID=\"user_roleperm_pv\" TabIndex=\"4\">" +

"    <div class=\"UserAdminContent\">" +

"        <div class=\"spacerBottom\">" +

"            <telerik:RadTabStrip ID=\"RadTabRolePerm\" runat=\"server\" MultiPageID=\"RadMultiPageRolePerm\" SelectedIndex=\"0\">" +

"                <Tabs>" +

"                    <telerik:RadTab runat=\"server\" Text=\"Roles\" Value=\"role\" TabIndex=\"0\" PageViewID=\"RadPageViewRoles\"></telerik:RadTab>" +

"                    <telerik:RadTab runat=\"server\" Text=\"AddtionalPerm\" Value=\"perm\" TabIndex=\"1\" PageViewID=\"RadPageViewPerms\"></telerik:RadTab>" +

"                </Tabs>" +

"            </telerik:RadTabStrip>" +

"        </div>" +

"        <telerik:RadMultiPage ID=\"RadMultiPageRolePerm\" runat=\"server\" SelectedIndex=\"0\">" +

"            <telerik:RadPageView runat=\"server\" ID=\"RadPageViewRoles\" TabIndex=\"0\">" +

"                <div id=\"UserRoleGrid\" class=\"UserAdminRolePermGrid\">" +

"                    <ul class=\"toolBar\">" +

"                        <li class=\"toolItem\">" +

"                            <asp:HyperLink ID=\"RoleAdd\" runat=\"server\" NavigateUrl=\"#\" onClick=\"addRole();return(false);\">" +

"                                <span class=\"glyphicons add\"></span></asp:HyperLink>" +

"                        </li>" +

"                        <li class=\"toolItem\">" +

"                            <asp:HyperLink ID=\"RoleDrop\" runat=\"server\" NavigateUrl=\"#\" onClick=\"dropRole();return(false);\">" +

"                                <span class=\"glyphicons remove\"></span></asp:HyperLink>" +

"                        </li>" +

"                        <li class=\"toolItem\">" +

"                            <asp:HyperLink ID=\"RoleEdit\" runat=\"server\" NavigateUrl=\"#\" onClick=\"editRole();return(false);\">" +

"                                <span class=\"glyphicons edit\"></span></asp:HyperLink>" +

"                        </li>" +

"                    </ul>" +

"                    <div id=\"RoleGrid\" class=\"RolePermAdminGrid\">" +

"                        <telerik:RadGrid ID=\"RoleRadGrid\" runat=\"server\" Width=\"100%\" AutoGenerateColumns=\"false\" AllowPaging=\"true\" PageSize=\"14\"" +

"                                         ShowHeader=\"true\" ShowFooter=\"false\" ShowGroupPanel=\"false\" ShowStatusBar=\"false\" OnNeedDataSource=\"RoleRadGrid_NeedDataSource\"" +

"                                         AllowMultiRowSelection=\"true\" AllowAutomaticInserts=\"false\" AllowAutomaticDeletes=\"false\" AllowAutomaticUpdates=\"false\" AllowSorting=\"true\" AllowFilteringByColumn=\"false\"" +

"                                         BorderStyle=\"None\" Style=\"overflow: auto;\">" +

"                            <MasterTableView TableLayout=\"Fixed\" Width=\"100%\" ClientDataKeyNames=\"ROLE_ID,ORG_ID\">" +

"                                <Columns>" +

"                                    <telerik:GridClientSelectColumn UniqueName=\"CheckboxSelectRole\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"RoleId\" HeaderText=\"\" DataField=\"ROLE_ID\" Visible=\"false\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"RoleName\" HeaderText=\"RoleName\" DataField=\"LABEL\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"50%\" ItemStyle-Width=\"50%\" ItemStyle-Wrap=\"false\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"OrgId\" HeaderText=\"\" DataField=\"ORG_ID\" Visible=\"false\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"OrgName\" HeaderText=\"OrgName\" DataField=\"ORG_LABEL\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"45%\" ItemStyle-Width=\"45%\" ItemStyle-Wrap=\"false\"/>" +

"                                </Columns>" +

"                                <PagerStyle AlwaysVisible=\"false\" Mode=\"NumericPages\"/>" +

"                            </MasterTableView>" +

"                            <HeaderStyle Font-Bold=\"true\"/>" +

"                            <ClientSettings Selecting-AllowRowSelect=\"true\">" +

"                                <ClientEvents OnRowDblClick=\"editRole\"/>" +

"                            </ClientSettings>" +

"                        </telerik:RadGrid>" +

"                    </div>" +

"                </div>" +

"            </telerik:RadPageView>" +

"            <telerik:RadPageView runat=\"server\" ID=\"RadPageViewPerms\" TabIndex=\"1\">" +

"                <div id=\"UserPermGrid\" class=\"UserAdminRolePermGrid\">" +

"                    <ul class=\"toolBar\">" +

"                        <li class=\"toolItem\">" +

"                            <asp:HyperLink ID=\"PermAdd\" runat=\"server\" NavigateUrl=\"#\" onClick=\"addPerm();return(false);\">" +

"                                <span class=\"glyphicons add\"></span></asp:HyperLink>" +

"                        </li>" +

"                        <li class=\"toolItem\">" +

"                            <asp:HyperLink ID=\"PermDrop\" runat=\"server\" NavigateUrl=\"#\" onClick=\"dropPerm();return(false);\">" +

"                                <span class=\"glyphicons remove\"></span></asp:HyperLink>" +

"                        </li>" +

"                        <li class=\"toolItem\">" +

"                            <asp:HyperLink ID=\"PermEdit\" runat=\"server\" NavigateUrl=\"#\" onClick=\"editPerm();return(false);\">" +

"                                <span class=\"glyphicons edit\"></span></asp:HyperLink>" +

"                        </li>" +

"                    </ul>" +

"                    <div id=\"PermGrid\" class=\"RolePermAdminGrid\">" +

"                        <telerik:RadGrid ID=\"PermRadGrid\" runat=\"server\" Width=\"100%\" AutoGenerateColumns=\"false\" AllowPaging=\"true\" PageSize=\"13\"" +

"                                         ShowHeader=\"true\" ShowFooter=\"false\" ShowGroupPanel=\"false\" ShowStatusBar=\"false\" OnNeedDataSource=\"PermRadGrid_NeedDataSource\"" +

"                                         AllowMultiRowSelection=\"true\" AllowAutomaticInserts=\"false\" AllowAutomaticDeletes=\"false\" AllowAutomaticUpdates=\"false\" AllowSorting=\"true\" AllowFilteringByColumn=\"false\"" +

"                                         BorderStyle=\"None\" Style=\"overflow: auto;\">" +

"                            <MasterTableView TableLayout=\"Fixed\" Width=\"100%\" ClientDataKeyNames=\"PERM_ID,ORG_ID\">" +

"                                <Columns>" +

"                                    <telerik:GridClientSelectColumn UniqueName=\"CheckboxSelectPerm\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"OrgId\" HeaderText=\"\" DataField=\"ORG_ID\" Visible=\"false\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"OrgName\" HeaderText=\"OrgName\" DataField=\"ORG_LABEL\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"30%\" ItemStyle-Width=\"30%\" ItemStyle-Wrap=\"false\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"PermCatName\" HeaderText=\"PermCatName\" DataField=\"PERMCAT_LABEL\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"25%\" ItemStyle-Width=\"25%\" ItemStyle-Wrap=\"false\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"PermId\" HeaderText=\"\" DataField=\"PERM_ID\" Visible=\"false\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"PermName\" HeaderText=\"PermName\" DataField=\"LABEL\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"25%\" ItemStyle-Width=\"25%\" ItemStyle-Wrap=\"false\"/>" +

"                                    <telerik:GridTemplateColumn UniqueName=\"PermLevel\" HeaderText=\"PermLevel\" HeaderStyle-Wrap=\"true\" HeaderStyle-Width=\"15%\" ItemStyle-Width=\"15%\" ItemStyle-Wrap=\"false\">" +

"                                        <ItemTemplate>" +

"                                            <%# GetPermType(Eval(\"LEVEL\").ToString()) %>" +

"                                        </ItemTemplate>" +

"                                    </telerik:GridTemplateColumn>" +

"                                </Columns>" +

"                                <PagerStyle AlwaysVisible=\"false\" Mode=\"NumericPages\"/>" +

"                            </MasterTableView>" +

"                            <HeaderStyle Font-Bold=\"true\"/>" +

"                            <ClientSettings Selecting-AllowRowSelect=\"true\">" +

"                                <ClientEvents OnRowDblClick=\"editPerm\"/>" +

"                            </ClientSettings>" +

"                        </telerik:RadGrid>" +

"                    </div>" +

"                </div>" +

"            </telerik:RadPageView>" +

"        </telerik:RadMultiPage>" +

"    </div>" +

"</telerik:RadPageView>" +

"<telerik:RadPageView runat=\"server\" ID=\"user_manageduser_pv\" TabIndex=\"5\">" +

"    <div class=\"UserAdminContent\">" +

"        <div class=\"spacerBottom\">" +

"            <telerik:RadTabStrip ID=\"RadTabManagedUsers\" runat=\"server\" MultiPageID=\"RadMultiManagedUsers\" SelectedIndex=\"0\">" +

"                <Tabs>" +

"                    <telerik:RadTab runat=\"server\" Text=\"Managed\" Value=\"managed\" TabIndex=\"0\" PageViewID=\"RadPageViewManaged\"></telerik:RadTab>" +

"                    <telerik:RadTab runat=\"server\" Text=\"AlternateManaged\" Value=\"alternatemanaged\" TabIndex=\"1\" PageViewID=\"RadPageViewAlternateManaged\"></telerik:RadTab>" +

"                </Tabs>" +

"            </telerik:RadTabStrip>" +

"        </div>" +

"        <telerik:RadMultiPage ID=\"RadMultiManagedUsers\" runat=\"server\" SelectedIndex=\"0\">" +

"            <telerik:RadPageView runat=\"server\" ID=\"RadPageViewManaged\" TabIndex=\"0\">" +

"                <div id=\"UserManagedUserGrid\" class=\"UserAdminManagedUserGrid\">" +

"                    <ul class=\"toolBar\">" +

"                        <li class=\"toolItem\">" +

"                            <asp:HyperLink ID=\"ManagedUserAdd\" runat=\"server\" NavigateUrl=\"#\" onClick=\"addManagedUser();return(false);\">" +

"                                <span class=\"glyphicons add\"></span></asp:HyperLink>" +

"                        </li>" +

"                        <li class=\"toolItem\">" +

"                            <asp:HyperLink ID=\"ManagedUserDrop\" runat=\"server\" NavigateUrl=\"#\" onClick=\"dropManagedUser();return(false);\">" +

"                                <span class=\"glyphicons remove\"></span></asp:HyperLink>" +

"                        </li>" +

"                    </ul>" +

"                    <div id=\"ManagedUserGrid\" class=\"ManagedUserAdminGrid\">" +

"                        <telerik:RadGrid ID=\"ManagedUserRadGrid\" runat=\"server\" Width=\"100%\" AutoGenerateColumns=\"false\" AllowPaging=\"true\" PageSize=\"14\"" +

"                                         ShowHeader=\"true\" ShowFooter=\"false\" ShowGroupPanel=\"false\" ShowStatusBar=\"false\" OnNeedDataSource=\"ManagedUserRadGrid_NeedDataSource\"" +

"                                         AllowMultiRowSelection=\"true\" AllowAutomaticInserts=\"false\" AllowAutomaticDeletes=\"false\" AllowAutomaticUpdates=\"false\" AllowSorting=\"true\" AllowFilteringByColumn=\"false\"" +

"                                         BorderStyle=\"None\" Style=\"overflow: auto;\">" +

"                            <MasterTableView TableLayout=\"Fixed\" Width=\"100%\" ClientDataKeyNames=\"ID,LNAME,FNAME\">" +

"                                <Columns>" +

"                                    <telerik:GridClientSelectColumn UniqueName=\"CheckboxSelectUser\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"UserId\" HeaderText=\"\" DataField=\"ID\" Visible=\"false\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"LastName\" HeaderText=\"LblLname\" DataField=\"LNAME\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"48%\" ItemStyle-Width=\"48%\" ItemStyle-Wrap=\"false\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"FirtName\" HeaderText=\"LblFname\" DataField=\"FNAME\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"47%\" ItemStyle-Width=\"47%\" ItemStyle-Wrap=\"false\"/>" +

"                                </Columns>" +

"                                <PagerStyle AlwaysVisible=\"false\" Mode=\"NumericPages\"/>" +

"                            </MasterTableView>" +

"                            <HeaderStyle Font-Bold=\"true\"/>" +

"                            <ClientSettings Selecting-AllowRowSelect=\"true\"/>" +

"                        </telerik:RadGrid>" +

"                    </div>" +

"                </div>" +

"            </telerik:RadPageView>" +

"            <telerik:RadPageView runat=\"server\" ID=\"RadPageRadPageViewAlternateManagedView2\" TabIndex=\"1\">" +

"                <div id=\"UserAlternateManagedUserGrid\" class=\"UserAdminManagedUserGrid\">" +

"                    <ul class=\"toolBar\">" +

"                        <li class=\"toolItem\">" +

"                            <asp:HyperLink ID=\"AlternateManagedUserAdd\" runat=\"server\" NavigateUrl=\"#\" onClick=\"addAlternateManagedUser();return(false);\">" +

"                                <span class=\"glyphicons add\"></span></asp:HyperLink>" +

"                        </li>" +

"                        <li class=\"toolItem\">" +

"                            <asp:HyperLink ID=\"AlternateManagedUserDrop\" runat=\"server\" NavigateUrl=\"#\" onClick=\"dropAlternateManagedUser();return(false);\">" +

"                                <span class=\"glyphicons remove\"></span></asp:HyperLink>" +

"                        </li>" +

"                    </ul>" +

"                    <div id=\"AlternateManagedUserGrid\" class=\"ManagedUserAdminGrid\">" +

"                        <telerik:RadGrid ID=\"AlternateManagedUserRadGrid\" runat=\"server\" Width=\"100%\" AutoGenerateColumns=\"false\" AllowPaging=\"true\" PageSize=\"14\"" +

"                                         ShowHeader=\"true\" ShowFooter=\"false\" ShowGroupPanel=\"false\" ShowStatusBar=\"false\" OnNeedDataSource=\"AlternateManagedUserRadGrid_NeedDataSource\"" +

"                                         AllowMultiRowSelection=\"true\" AllowAutomaticInserts=\"false\" AllowAutomaticDeletes=\"false\" AllowAutomaticUpdates=\"false\" AllowSorting=\"true\" AllowFilteringByColumn=\"false\"" +

"                                         BorderStyle=\"None\" Style=\"overflow: auto;\">" +

"                            <MasterTableView TableLayout=\"Fixed\" Width=\"100%\" ClientDataKeyNames=\"ID,LNAME,FNAME\">" +

"                                <Columns>" +

"                                    <telerik:GridClientSelectColumn UniqueName=\"CheckboxSelectUser\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"UserId\" HeaderText=\"\" DataField=\"ID\" Visible=\"false\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"LastName\" HeaderText=\"LblLname\" DataField=\"LNAME\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"48%\" ItemStyle-Width=\"48%\" ItemStyle-Wrap=\"false\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"FirtName\" HeaderText=\"LblFname\" DataField=\"FNAME\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"47%\" ItemStyle-Width=\"47%\" ItemStyle-Wrap=\"false\"/>" +

"                                </Columns>" +

"                                <PagerStyle AlwaysVisible=\"false\" Mode=\"NumericPages\"/>" +

"                            </MasterTableView>" +

"                            <HeaderStyle Font-Bold=\"true\"/>" +

"                            <ClientSettings Selecting-AllowRowSelect=\"true\"/>" +

"                        </telerik:RadGrid>" +

"                    </div>" +

"                </div>" +

"            </telerik:RadPageView>" +

"        </telerik:RadMultiPage>" +

"    </div>" +

"</telerik:RadPageView>" +

"<telerik:RadPageView runat=\"server\" ID=\"user_tutor_pv\" TabIndex=\"6\">" +

"    <div class=\"UserAdminContent\">" +

"        <div class=\"spacerBottom\">" +

"            <telerik:RadTabStrip ID=\"RadTabTutor\" runat=\"server\" MultiPageID=\"RadMultiPageTutor\" SelectedIndex=\"0\">" +

"                <Tabs>" +

"                    <telerik:RadTab runat=\"server\" Text=\"Courses\" Value=\"crs\" TabIndex=\"0\" PageViewID=\"RadPageViewTutorCourses\"></telerik:RadTab>" +

"                    <telerik:RadTab runat=\"server\" Text=\"Classes\" Value=\"cls\" TabIndex=\"1\" PageViewID=\"RadPageViewTutorClasses\"></telerik:RadTab>" +

"                </Tabs>" +

"            </telerik:RadTabStrip>" +

"        </div>" +

"        <telerik:RadMultiPage ID=\"RadMultiPageTutor\" runat=\"server\" SelectedIndex=\"0\">" +

"            <telerik:RadPageView runat=\"server\" ID=\"RadPageViewTutorCourses\" TabIndex=\"0\">" +

"                <div id=\"UserTutorCrsGrid\" class=\"UserAdminCrsClsGrid\">" +

"                    <ul class=\"toolBar\">" +

"                        <li class=\"toolItem\">" +

"                            <asp:HyperLink ID=\"TutorCrsAdd\" runat=\"server\" NavigateUrl=\"#\" onClick=\"addTutorCrs();return(false);\">" +

"                                <span class=\"glyphicons add\"></span></asp:HyperLink>" +

"                        </li>" +

"                        <li class=\"toolItem\">" +

"                            <asp:HyperLink ID=\"TutorCrsDrop\" runat=\"server\" NavigateUrl=\"#\" onClick=\"dropTutorCrs();return(false);\">" +

"                                <span class=\"glyphicons remove\"></span></asp:HyperLink>" +

"                        </li>" +

"                    </ul>" +

"                    <div id=\"TutorCrsGrid\" class=\"CrsClsAdminGrid\">" +

"                        <telerik:RadGrid ID=\"TutorCrsRadGrid\" runat=\"server\" Width=\"100%\" AutoGenerateColumns=\"false\" AllowPaging=\"true\" PageSize=\"14\"" +

"                                         ShowHeader=\"true\" ShowFooter=\"false\" ShowGroupPanel=\"false\" ShowStatusBar=\"false\" OnNeedDataSource=\"TutorCrsRadGrid_NeedDataSource\"" +

"                                         AllowMultiRowSelection=\"true\" AllowAutomaticInserts=\"false\" AllowAutomaticDeletes=\"false\" AllowAutomaticUpdates=\"false\" AllowSorting=\"true\" AllowFilteringByColumn=\"false\"" +

"                                         BorderStyle=\"None\" Style=\"overflow: auto;\">" +

"                            <MasterTableView TableLayout=\"Fixed\" Width=\"100%\" ClientDataKeyNames=\"ID\">" +

"                                <Columns>" +

"                                    <telerik:GridClientSelectColumn UniqueName=\"CheckboxSelectCrs\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"CrsId\" HeaderText=\"\" DataField=\"ID\" Visible=\"false\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"CrsName\" HeaderText=\"CrsName\" DataField=\"NAME\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"85%\" ItemStyle-Width=\"85%\" ItemStyle-Wrap=\"false\"/>" +

"                                    <telerik:GridTemplateColumn UniqueName=\"CrsActive\" HeaderText=\"CrsActive\" DataField=\"DISABLE\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"10%\" HeaderStyle-HorizontalAlign=\"Center\" ItemStyle-Width=\"10%\" ItemStyle-HorizontalAlign=\"Center\">" +

"                                        <ItemTemplate>" +

"                                            <asp:CheckBox ID=\"ChkActive\" runat=\"server\" Checked='<%# DataBinder.Eval(Container.DataItem, \"DISABLE\").ToString() == \"0\" ? true : false %>' Enabled=\"false\"/>" +

"                                        </ItemTemplate>" +

"                                    </telerik:GridTemplateColumn>" +

"                                </Columns>" +

"                                <PagerStyle AlwaysVisible=\"false\" Mode=\"NumericPages\"/>" +

"                            </MasterTableView>" +

"                            <HeaderStyle Font-Bold=\"true\"/>" +

"                            <ClientSettings Selecting-AllowRowSelect=\"true\">" +

"                            </ClientSettings>" +

"                        </telerik:RadGrid>" +

"                    </div>" +

"                </div>" +

"            </telerik:RadPageView>" +

"            <telerik:RadPageView runat=\"server\" ID=\"RadPageViewTutorClasses\" TabIndex=\"1\">" +

"                <div id=\"UserTutorClsGrid\" class=\"UserAdminCrsClsGrid\">" +

"                    <ul class=\"toolBar\">" +

"                        <li class=\"toolItem\">" +

"                            <asp:HyperLink ID=\"TutorClsAdd\" runat=\"server\" NavigateUrl=\"#\" onClick=\"addTutorCls();return(false);\">" +

"                                <span class=\"glyphicons add\"></span></asp:HyperLink>" +

"                        </li>" +

"                        <li class=\"toolItem\">" +

"                            <asp:HyperLink ID=\"TutorClsDrop\" runat=\"server\" NavigateUrl=\"#\" onClick=\"dropTutorCls();return(false);\">" +

"                                <span class=\"glyphicons remove\"></span></asp:HyperLink>" +

"                        </li>" +

"                    </ul>" +

"                    <div id=\"TutorClsGrid\" class=\"CrsClsAdminGrid\">" +

"                        <telerik:RadGrid ID=\"TutorClsRadGrid\" runat=\"server\" Width=\"100%\" AutoGenerateColumns=\"false\" AllowPaging=\"true\" PageSize=\"14\"" +

"                                         ShowHeader=\"true\" ShowFooter=\"false\" ShowGroupPanel=\"false\" ShowStatusBar=\"false\" OnNeedDataSource=\"TutorClsRadGrid_NeedDataSource\"" +

"                                         AllowMultiRowSelection=\"true\" AllowAutomaticInserts=\"false\" AllowAutomaticDeletes=\"false\" AllowAutomaticUpdates=\"false\" AllowSorting=\"true\" AllowFilteringByColumn=\"false\"" +

"                                         BorderStyle=\"None\" Style=\"overflow: auto;\">" +

"                            <MasterTableView TableLayout=\"Fixed\" Width=\"100%\" ClientDataKeyNames=\"ID\">" +

"                                <Columns>" +

"                                    <telerik:GridClientSelectColumn UniqueName=\"CheckboxSelectCls\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"ClsId\" HeaderText=\"\" DataField=\"ID\" Visible=\"false\"/>" +

"                                    <telerik:GridBoundColumn UniqueName=\"ClsName\" HeaderText=\"ClsName\" DataField=\"NAME\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"85%\" ItemStyle-Width=\"85%\" ItemStyle-Wrap=\"false\"/>" +

"                                    <telerik:GridTemplateColumn UniqueName=\"ClsActive\" HeaderText=\"ClsActive\" DataField=\"DISABLE\" HeaderStyle-Wrap=\"false\" HeaderStyle-Width=\"10%\" HeaderStyle-HorizontalAlign=\"Center\" ItemStyle-Width=\"10%\" ItemStyle-HorizontalAlign=\"Center\">" +

"                                        <ItemTemplate>" +

"                                            <asp:CheckBox ID=\"ChkActive\" runat=\"server\" Checked='<%# DataBinder.Eval(Container.DataItem, \"DISABLE\").ToString() == \"0\" ? true : false %>' Enabled=\"false\"/>" +

"                                        </ItemTemplate>" +

"                                    </telerik:GridTemplateColumn>" +

"                                </Columns>" +

"                                <PagerStyle AlwaysVisible=\"false\" Mode=\"NumericPages\"/>" +

"                            </MasterTableView>" +

"                            <HeaderStyle Font-Bold=\"true\"/>" +

"                            <ClientSettings Selecting-AllowRowSelect=\"true\">" +

"                            </ClientSettings>" +

"                        </telerik:RadGrid>" +

"                    </div>" +

"                </div>" +

"            </telerik:RadPageView>" +

"        </telerik:RadMultiPage>" +

"    </div>" +

"</telerik:RadPageView>" +

"</telerik:RadMultiPage>" +

"<div class=\"WinButtonAdmin\">" +

"    <div class=\"WinButtonDetailsAdmin\">" +

"        <asp:HyperLink ID=\"LblConnectAs\" CssClass=\"button otherAction\" runat=\"server\" NavigateUrl=\"\" Target=\"_top\" Text=\"LblConnectAs\"/>" +

"        <asp:Button id=\"BtnCancel\" runat=\"server\" Cssclass=\"button otherAction short\" OnClientClick=\"" +

"CloseRadWindow();\"/>" +

"        <asp:Button id=\"BtnSave\" runat=\"server\" Cssclass=\"button mainAction short\" OnClick=\"BtnSave_Click\" OnClientClick=\"if (!checkForm(theForm)) return (false);\"/>" +

"    </div>" +

"</div>" +

"</div>" +

"</div>" +

"<telerik:RadAjaxLoadingPanel ID=\"WindowRadAjaxLoadingPanel\" runat=\"server\" Transparency=\"30\" MinDisplayTime=\"100\"/>" +

"<WBT:RadWindowTranslation id=\"radwindowtranslation\" runat=\"server\"/>" +

"</form>" +

"</body>" +

"</html>";



            ASP.Document root = new ASP.Document(asp);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            List<ASP.Tag> tlmp = new List<Tag>();

            ParseWBT35 pt = new ParseWBT35();



            XmlDocument doc;
            Writer w = new Writer();





            DirectoryInfo d = new DirectoryInfo(@"C:\ASPX_files");
            FileInfo f = default(FileInfo);
            List<XmlDocument> lx = new List<XmlDocument>();
            foreach (var file in d.GetFiles("*.aspx"))
            {
                doc = pt.ParseAspx(@"c:\ASPX_files\" + file.Name);
                    w.XmlToFile(doc, file.Name.Replace(".aspx", ".xml"));
            }





            stopWatch.Stop();
            Console.WriteLine("Elapsed time : " + stopWatch.ElapsedMilliseconds);
        }

        [TestMethod]
        public void TestSingle35ToXml()
        {


            List<ASP.Tag> tlmp = new List<Tag>();

            ParseWBT35 pt = new ParseWBT35();



            XmlDocument doc = new XmlDocument();


            DirectoryInfo d = new DirectoryInfo(@"C:\ASPX_FILES_SAVE");
            FileInfo[] f;
            //default(FileInfo);
            f = d.GetFiles("webinare.aspx");
            Writer w = new Writer();
            doc = pt.ParseAspx(@"c:\ASPX_FILES_SAVE\" + f.First().Name);
            w.XmlToFile(doc, f.First().Name.Replace(".aspx", ".xml"));



            /* var stringWriter = new StringWriter();
             var xmlTextWriter = XmlWriter.Create(stringWriter);

             doc.WriteTo(xmlTextWriter);
             xmlTextWriter.Flush();
             Console.WriteLine(stringWriter.GetStringBuilder().ToString());

             */

        }
    }
}

