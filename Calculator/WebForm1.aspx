<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Calculator.WebForm1" StylesheetTheme="" Theme="" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>God, save us!</title>
</head>

<body>

    <div id="background">
        <form id="form1" runat="server">
            <asp:Panel ID="Panel1" runat="server" CssClass="auto-style2" Height="347px" BackColor="White" Width="490px">
                <div style="height: 290px; width: 456px; margin: 2%;">


                    <asp:TextBox ID="calculatorEquationTxt" runat="server" Width="100%" Enabled="False" Font-Names="Arial" Font-Size="X-Large" MaxLength="100000"></asp:TextBox>
                    <asp:TextBox ID="answerTxt" runat="server" Width="100%" Enabled="False" Font-Names="Arial" Font-Size="X-Large" MaxLength="100000"></asp:TextBox>
                    <div style="height: auto; width: 370px; top: 83px; padding: 0px; margin-left: 0px; margin-right: 0px; margin-top: 0px;">
                        <asp:Button ID="sevenBtn" runat="server" Font-Size="XX-Large" OnClick="Equation_Click" Text="7" Width="89px" />
                        <asp:Button ID="eightBtn" runat="server"  Font-Size="XX-Large" OnClick="Equation_Click" Text="8" Width="89px" />
                        <asp:Button ID="nineBtn" runat="server" Font-Size="XX-Large" OnClick="Equation_Click" Text="9" Width="89px" />
                        <asp:Button ID="divideBtn" runat="server" Font-Size="XX-Large" OnClick="Equation_Click" Text="/" Width="89px" />
                        <asp:Button ID="fourBtn" runat="server" Font-Size="XX-Large" OnClick="Equation_Click" Text="4" Width="89px" />
                        <asp:Button ID="fiveBtn" runat="server" Font-Size="XX-Large" OnClick="Equation_Click" Text="5" Width="89px" />
                        <asp:Button ID="sixBtn" runat="server" Font-Size="XX-Large" OnClick="Equation_Click" Text="6" Width="89px" />
                        <asp:Button ID="timesBtn" runat="server" Font-Size="XX-Large" OnClick="Equation_Click" Text="*" Width="89px"/>
                        <asp:Button ID="oneBtn" runat="server" Font-Size="XX-Large" OnClick="Equation_Click" Text="1" Width="89px" />
                        <asp:Button ID="twoBtn" runat="server" Font-Size="XX-Large" OnClick="Equation_Click" Text="2" Width="89px" />
                        <asp:Button ID="threeBtn" runat="server" Font-Size="XX-Large" OnClick="Equation_Click" Text="3" Width="89px" />
                        <asp:Button ID="addBtn" runat="server" Font-Size="XX-Large" OnClick="Equation_Click" Text="+" Width="89px" />
                        <asp:Button ID="zeroBtn" runat="server" Font-Size="XX-Large" OnClick="Equation_Click" Text="0" Width="89px" />
                        <asp:Button ID="decimalBtn" runat="server" Font-Size="XX-Large" OnClick="Equation_Click" Text="." Width="89px" />
                        <asp:Button ID="equalBtn" runat="server" Font-Size="XX-Large" OnClick="equalsBtn_Click" Text="=" Width="89px" />
                        <asp:Button ID="subtractBtn" runat="server" Font-Size="XX-Large" OnClick="Equation_Click" Text="-" Width="89px" />
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="33px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="370px">
                        </asp:DropDownList>
                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Height="33px" Width="370px"> 
                            <asp:ListItem Selected="True">Metal</asp:ListItem>
                            <asp:ListItem>Ancient Greece</asp:ListItem>
                            <asp:ListItem Value="mlp">Surprise :)</asp:ListItem>
                            <asp:ListItem Value="barbie">Party Theme?</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="back" style="height: auto; width: 89px; top: 79px; left: 380px; position: absolute; margin: 0px; padding: 0px; border: 0px;">
                        <asp:Button ID="backBtn" runat="server" Font-Size="XX-Large" OnClick="backBtn_Click" Text="Back" Width="89px" />
                        <asp:Button ID="clearBtn" runat="server" Font-Size="XX-Large" OnClick="clearBtn_Click" Text="Clear" Width="89px" />
                    </div>
                </div>
            </asp:Panel>
        </form>
    </div>
</body>
</html>
