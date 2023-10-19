


Public Class Form1
    Private Sub RegisterButton_Click(sender As Object, e As EventArgs) Handles RegisterButton.Click
        ' Create an instance of the Register form
        Dim Register As New Register()

        ' Show the Register form
        Register.Show()

        ' Optionally, you can hide the current form
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        ' Create an instance of the Login form
        Dim loginForm As New Login()

        ' Show the Login form
        loginForm.Show()

        Me.Hide()
    End Sub
End Class
