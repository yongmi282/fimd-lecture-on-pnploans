<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserReportPage.aspx.cs" Inherits="PnpLoan.Web.UserReportPage" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="928px">
            <LocalReport ReportPath="UserReport.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="PnpLoan.Web.PnpLoanDataSetTableAdapters.SecurityUserTableAdapter"></asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
