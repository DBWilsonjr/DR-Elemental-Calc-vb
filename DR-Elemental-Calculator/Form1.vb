'Dannie Wilson
'Dungeon Rush Elemental Calculator

Option Explicit On
Option Strict On
Option Infer Off

Public Class Form1

    Private Sub frmLoad(sender As Object, e As EventArgs) Handles Me.Load
        txtBagE.Focus()
        For i As Integer = 0 To 10 Step 1
            cmbEarth.Items.Add(i)
            cmbPoison.Items.Add(i)
            cmbWater.Items.Add(i)
            cmbThunder.Items.Add(i)
            cmbFire.Items.Add(i)
            cmbAir.Items.Add(i)
            cmbLegE.Items.Add(i)
            cmbLegP.Items.Add(i)
            cmbLegF.Items.Add(i)
            cmbLegT.Items.Add(i)
        Next
        cmbEarth.SelectedIndex = 0
        cmbPoison.SelectedIndex = 0
        cmbWater.SelectedIndex = 0
        cmbThunder.SelectedIndex = 0
        cmbFire.SelectedIndex = 0
        cmbAir.SelectedIndex = 0
        cmbLegE.SelectedIndex = 0
        cmbLegP.SelectedIndex = 0
        cmbLegF.SelectedIndex = 0
        cmbLegT.SelectedIndex = 0
    End Sub

    Private Sub KeyBlocker(sender As Object, e As KeyPressEventArgs) Handles txtBagA.KeyPress, txtBagE.KeyPress, txtBagF.KeyPress, txtBagP.KeyPress, txtBagT.KeyPress, txtBagW.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnClick(sender As Object, e As EventArgs) Handles btnCheck.Click
        Dim intEa, intPo, intWa, intTh, intFi, intAi As Integer

        Counter(intEa, intPo, intWa, intTh, intFi, intAi)
        ShadowCalc(intEa, intPo, intWa, intTh, intFi, intAi)
        LightCalc(intEa, intPo, intWa, intTh, intFi, intAi)
    End Sub

    Private Sub Counter(ByRef Ea As Integer, ByRef Po As Integer, ByRef Wa As Integer, ByRef Th As Integer, ByRef Fi As Integer, ByRef Ai As Integer)
        Dim temp As Integer

        Integer.TryParse(txtBagE.Text.ToString(), Ea)
        Integer.TryParse(cmbEarth.SelectedIndex.ToString(), temp)
        Ea = Ea + (temp * 10)
        Integer.TryParse(txtBagP.Text.ToString(), Po)
        Integer.TryParse(cmbPoison.SelectedIndex.ToString(), temp)
        Po = Po + (temp * 10)
        Integer.TryParse(txtBagW.Text.ToString(), Wa)
        Integer.TryParse(cmbWater.SelectedIndex.ToString(), temp)
        Wa = Wa + (temp * 10)
        Integer.TryParse(txtBagT.Text.ToString(), Th)
        Integer.TryParse(cmbThunder.SelectedIndex.ToString(), temp)
        Th = Th + (temp * 10)
        Integer.TryParse(txtBagF.Text.ToString(), Fi)
        Integer.TryParse(cmbFire.SelectedIndex.ToString(), temp)
        Fi = Fi + (temp * 10)
        Integer.TryParse(txtBagA.Text.ToString(), Ai)
        Integer.TryParse(cmbAir.SelectedIndex.ToString(), temp)
        Ai = Ai + (temp * 10)
    End Sub

    Private Sub ShadowCalc(E As Integer, P As Integer, W As Integer, T As Integer, F As Integer, A As Integer)
        'This Champ needs 2 Fire Legends, 2 Poison Legends, 1 Earth Legend, and 1 Thunder Legend
        Dim Fire, Poison, Earth, Thunder As Integer
        Integer.TryParse(cmbLegE.SelectedIndex.ToString(), Earth)
        Integer.TryParse(cmbLegF.SelectedIndex.ToString(), Fire)
        Integer.TryParse(cmbLegP.SelectedIndex.ToString(), Poison)
        Integer.TryParse(cmbLegT.SelectedIndex.ToString(), Thunder)

        If Fire < 2 Then
            Do
                If F >= 40 And W >= 20 Then
                    Fire += 1
                    F = F - 40
                    A = A - 20
                Else
                    Exit Do
                End If
            Loop Until Fire = 2
        End If

        If Earth < 1 Then
            Do
                If E >= 40 And W >= 20 Then
                    Earth += 1
                    E = E - 40
                    W = W - 20
                Else
                    Exit Do
                End If
            Loop Until Earth = 1
        End If

        If Poison < 2 Then
            Do
                If P >= 40 And W >= 20 Then
                    Poison += 1
                    P = P - 40
                    W = W - 20
                Else
                    Exit Do
                End If
            Loop Until Poison = 2
        End If

        If Thunder < 1 Then
            Do
                If T >= 40 And A >= 20 Then
                    Thunder += 1
                    T = T - 40
                    A = A - 20
                Else
                    Exit Do
                End If
            Loop Until Thunder = 1
        End If

        E = E + (Earth * 40)
        P = P + (Poison * 40)
        W = W + (Earth * 20) + (Poison * 20)
        F = F + (Fire * 40)
        T = T + (Thunder * 40)
        A = A + (Fire * 20) + (Thunder * 20)

        If Fire >= 2 And Poison >= 2 And Earth >= 1 And Thunder >= 1 Then
            lblSChamp.Text = "Champ: Yes"
        Else
            lblSChamp.Text = "Champ: No"
        End If
        lblSE.Text = E.ToString() + "/40"
        If E >= 40 Then
            Label7.Text = "Earth Requirement: Met!"
            lblSE.ForeColor = Color.Green
        Else
            Label7.Text = "Earth Requirement: Not Met"
            lblSE.ForeColor = Color.Black
        End If
        lblSP.Text = P.ToString() + "/80"
        If P >= 80 Then
            Label8.Text = "Poison Requirement: Met!"
            lblSP.ForeColor = Color.Green
        Else
            Label8.Text = "Poison Requirement: Not Met"
            lblSP.ForeColor = Color.Black
        End If
        lblSW.Text = W.ToString() + "/60"
        If W >= 60 Then
            Label11.Text = "Water Requirement: Met!"
            lblSW.ForeColor = Color.Green
        Else
            Label11.Text = "Water Requirement: Not Met"
            lblSW.ForeColor = Color.Black
        End If
        lblSF.Text = F.ToString() + "/80"
        If F >= 80 Then
            Label9.Text = "Fire Requirement: Met!"
            lblSF.ForeColor = Color.Green
        Else
            Label9.Text = "Fire Requirement: Not Met"
            lblSF.ForeColor = Color.Black
        End If
        lblST.Text = T.ToString() + "/40"
        If T >= 40 Then
            Label10.Text = "Thunder Requirement: Met!"
            lblST.ForeColor = Color.Green
        Else
            Label10.Text = "Thunder Requirement: Not Met"
            lblST.ForeColor = Color.Black
        End If
        lblSA.Text = A.ToString() + "/60"
        If A >= 60 Then
            Label12.Text = "Air Requirement: Met!"
            lblSA.ForeColor = Color.Green
        Else
            Label12.Text = "Air Requirement: Not Met"
            lblSA.ForeColor = Color.Black
        End If
    End Sub

    Private Sub LightCalc(E As Integer, P As Integer, W As Integer, T As Integer, F As Integer, A As Integer)
        'This Champ needs 2 Thunder Legends, 2 Earth Legends, 1 Fire Legend, and 1 Poison Legend
        Dim Fire, Poison, Earth, Thunder As Integer
        Integer.TryParse(cmbLegE.SelectedIndex.ToString(), Earth)
        Integer.TryParse(cmbLegF.SelectedIndex.ToString(), Fire)
        Integer.TryParse(cmbLegP.SelectedIndex.ToString(), Poison)
        Integer.TryParse(cmbLegT.SelectedIndex.ToString(), Thunder)

        If Fire < 1 Then
            Do
                If F >= 40 And W >= 20 Then
                    Fire += 1
                    F = F - 40
                    A = A - 20
                Else
                    Exit Do
                End If
            Loop Until Fire = 1
        End If

        If Earth <= 2 Then
            Do
                If E >= 40 And W >= 20 Then
                    Earth += 1
                    E = E - 40
                    W = W - 20
                Else
                    Exit Do
                End If
            Loop Until Earth = 2
        End If

        If Poison < 1 Then
            Do
                If P >= 40 And W >= 20 Then
                    Poison += 1
                    P = P - 40
                    W = W - 20
                Else
                    Exit Do
                End If
            Loop Until Poison = 1
        End If

        If Thunder < 2 Then
            Do
                If T >= 40 And A >= 20 Then
                    Thunder += 1
                    T = T - 40
                    A = A - 20
                Else
                    Exit Do
                End If
            Loop Until Thunder = 2
        End If

        E = E + (Earth * 40)
        P = P + (Poison * 40)
        W = W + (Earth * 20) + (Poison * 20)
        F = F + (Fire * 40)
        T = T + (Thunder * 40)
        A = A + (Fire * 20) + (Thunder * 20)

        If Thunder >= 2 And Earth >= 2 And Fire >= 1 And Poison >= 1 Then
            lblHLChamp.Text = "Champ: Yes"
        Else
            lblHLChamp.Text = "Champ: No"
        End If

        lblHLE.Text = E.ToString + "/80"
        If (E - 80) >= 0 Then
            lblHLE.ForeColor = Color.Green
            Label30.Text = "Earth Requirement: Met!"
        Else
            lblHLE.ForeColor = Color.Black
            Label30.Text = "Earth Requirement: Not Met"
        End If

        lblHLP.Text = P.ToString + "/40"
        If (P - 40) >= 0 Then
            lblHLP.ForeColor = Color.Green
            Label29.Text = "Poison Requirement: Met!"
        Else
            lblHLP.ForeColor = Color.Black
            Label29.Text = "Poison Requirement: Not Met"
        End If

        lblHLF.Text = F.ToString + "/40"
        If (F - 40) >= 0 Then
            lblHLF.ForeColor = Color.Green
            Label28.Text = "Fire Requirement: Met!"
        Else
            lblHLF.ForeColor = Color.Black
            Label28.Text = "Fire Requirement: Not Met"
        End If

        lblHLT.Text = T.ToString + "/80"
        If (T - 80) >= 0 Then
            lblHLT.ForeColor = Color.Green
            Label27.Text = "Thunder Requirement: Met!"
        Else
            lblHLT.ForeColor = Color.Black
            Label27.Text = "Thunder Requirement: Not Met"
        End If

        lblHLW.Text = W.ToString + "/60"
        If (W - 60) >= 0 Then
            lblHLW.ForeColor = Color.Green
            Label26.Text = "Water Requirement: Met!"
        Else
            lblHLW.ForeColor = Color.Black
            Label26.Text = "Water Requirement: Not Met"
        End If

        lblHLA.Text = A.ToString + "/60"
        If (A - 60) >= 0 Then
            lblHLA.ForeColor = Color.Green
            Label25.Text = "Air Requirement: Met!"
        Else
            lblHLA.ForeColor = Color.Black
            Label25.Text = "Air Requirement: Not Met"
        End If
    End Sub
End Class
