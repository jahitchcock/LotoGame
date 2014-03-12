Public Class frmMain

    Dim arLotto(61) As Integer
    Dim lbl As New Label()

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim x, matches, y As Integer
        y = 0
        Select Case Val(txtNum2.Text)
            Case Is = Val(txtNum1.Text), Val(txtNum3.Text), Val(txtNum4.Text), Val(txtNum5.Text), Val(txtNum6.Text)
                MessageBox.Show("Please enter a number only one time")
                y = 1
            Case Else
                Select Case Val(txtNum3.Text)
                    Case Is = Val(txtNum1.Text), Val(txtNum4.Text), Val(txtNum5.Text), Val(txtNum6.Text)
                        MessageBox.Show("Please enter a number only one time")
                        y = 1
                End Select
                Select Case Val(txtNum4.Text)
                    Case Is = Val(txtNum1.Text), Val(txtNum5.Text), Val(txtNum6.Text)
                        MessageBox.Show("Please enter a number only one time")
                        y = 1
                End Select
                Select Case Val(txtNum5.Text)
                    Case Is = Val(txtNum1.Text), Val(txtNum6.Text)
                        MessageBox.Show("Please enter a number only one time")
                        y = 1
                End Select
                Select Case Val(txtNum6.Text)
                    Case Is = Val(txtNum1.Text)
                        MessageBox.Show("Please enter a number only one time")
                        y = 1
                End Select

                If y = 0 Then
                    matches = 0
                    For x = 1 To 6
                        If (Val(txtNum1.Text) = arLotto(x - 1)) Then
                            matches += 1
                        ElseIf (Val(txtNum2.Text) = arLotto(x - 1)) Then
                            matches += 1
                        ElseIf (Val(txtNum3.Text) = arLotto(x - 1)) Then
                            matches += 1
                        ElseIf (Val(txtNum4.Text) = arLotto(x - 1)) Then
                            matches += 1
                        ElseIf (Val(txtNum5.Text) = arLotto(x - 1)) Then
                            matches += 1
                        ElseIf (Val(txtNum6.Text) = arLotto(x - 1)) Then
                            matches += 1
                        End If

                    Next
                    winnings(matches)

                    lblBall1.Text = arLotto(0).ToString
                    lblBall2.Text = arLotto(1).ToString
                    lblBall3.Text = arLotto(2).ToString
                    lblBall4.Text = arLotto(3).ToString
                    lblBall5.Text = arLotto(4).ToString
                    lblBall6.Text = arLotto(5).ToString
                    btnSubmit.Visible = False
                End If
            End Select
        btnClear.Visible = True
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtNum1.Text = ""
        txtNum2.Text = ""
        txtNum3.Text = ""
        txtNum4.Text = ""
        txtNum5.Text = ""
        txtNum6.Text = ""
        lblBall1.Text = "?"
        lblBall2.Text = "?"
        lblBall3.Text = "?"
        lblBall4.Text = "?"
        lblBall5.Text = "?"
        lblBall6.Text = "?"
        btnSubmit.Visible = True
        btnClear.Visible = False
        Randomize()

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        labels()
        Randomize()
    End Sub

    Private Sub Randomize()
        Dim i, x, y, temp As Integer
        Dim rnd As New Random
        For i = 1 To 60
            arLotto(i) = i
        Next

        For x = 0 To (arLotto.Length - 1)
            y = rnd.Next(0, arLotto.Length - 1)
            temp = arLotto(x)
            arLotto(x) = arLotto(y)
            arLotto(y) = temp
        Next
    End Sub

    Private Sub labels()
        Dim a, b, c As Integer
        Dim name As String

        c = 1
        For a = 1 To 3
            For b = 1 To 20
                name = ("lbl" & c.ToString)
                Me.lbl.Text = c.ToString
                'Me.lbl.Location = New System.Drawing.Point(b * 10, a * 10)
                Me.lbl.Visible = True
                Me.lbl.Name = name
                Me.Controls.Add(lbl)
                c += 1
            Next
        Next

    End Sub
    Private Sub winnings(ByVal matches)
        Select Case matches
            Case Is = 4
                MessageBox.Show("You win $50!")
            Case Is = 5
                MessageBox.Show("You win $500!")
            Case Is = 6
                MessageBox.Show("You win $5000!")
            Case Else
                MessageBox.Show("You had " & matches & " matches!")

        End Select
    End Sub

   
End Class
