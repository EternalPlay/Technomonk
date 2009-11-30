<%@ Page Title="" Language="C#" MasterPageFile="~/Technomonk.Master" AutoEventWireup="true"
    CodeBehind="ActiveCycle.aspx.cs" Inherits="EternalPlay.Technomonk.Web.ActiveCycle" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .QualityList TD {
            padding: 5px;
        }
        
        .QualityList TD.Sequence {
            padding-right: 2em;
        }
        
        .QualityList TD.Name {
            padding-right: 2em;
        }

        .QualityList TR.Past TD {
            font-weight: normal;
        }
        
        .QualityList TR.Present TD {
            font-weight: bold;
            font-style: italic;
        }
        
        .QualityList TR.Future TD {
            font-weight: normal;
            color: #999999;
        }        

    </style>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentHeader" runat="server">
    <asp:Localize runat="server" meta:resourcekey="Title" />
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentMain" runat="server">
    
    <table class="QualityList">
        <tbody>
            <tr class="Past">
                <td class="Sequence">Week 1</td>
                <td class="Name">Mental Health</td>
                <td class="Status">Practice</td>
            </tr>
            <tr class="Present">
                <td class="Sequence">Week 2</td>
                <td class="Name">Physical Health</td>
                <td class="Status">Active</td>
            </tr>
            <tr class="Future">
                <td class="Sequence">Week 3</td>
                <td class="Name">Financial Health</td>
                <td class="Status">&nbsp;</td>
            </tr>
            <tr class="Future">
                <td class="Sequence">Week 4</td>
                <td class="Name">Social Health</td>
                <td class="Status">&nbsp;</td>
            </tr>
            <tr class="Future">
                <td class="Sequence">Week 5</td>
                <td class="Name">Always Learning</td>
                <td class="Status">&nbsp;</td>
            </tr>   
            <tr class="Future">
                <td class="Sequence">Week 6</td>
                <td class="Name">Always Teaching</td>
                <td class="Status">&nbsp;</td>
            </tr>   
            <tr class="Future">
                <td class="Sequence">Week 7</td>
                <td class="Name">Always Creating</td>
                <td class="Status">&nbsp;</td>
            </tr>  
            <tr class="Future">
                <td class="Sequence">Week 8</td>
                <td class="Name">Planning & Rest</td>
                <td class="Status">&nbsp;</td>
            </tr>                                                                                    
        </tbody>    
    </table>
    
</asp:Content>
