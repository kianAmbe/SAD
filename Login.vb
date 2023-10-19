Imports MySql.Data.MySqlClient

Public Class Login
    Dim conn As MySqlConnection
    Dim connectionString As String

    Public Sub New()
        InitializeComponent()
        ' Initialize the connection string with your MySQL database details
        connectionString = "Server=localhost;Database=dbsad;Uid=root;Pwd=;"
        conn = New MySqlConnection(connectionString)
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Get user input from the login form
        Dim username As String = UsernameText.Text
        Dim password As String = PasswordText.Text

        ' Perform basic input validation (you should add more extensive validation)
        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please fill in all fields.")
            Return
        End If

        ' Check if the provided username and password are valid
        If IsLoginValid(username, password) Then
            MessageBox.Show("Login successful")

            ' Open the Welcome form and close the current login form
            Dim welcomeForm As New Welcome()
            welcomeForm.Show()
            Me.Close()
        Else
            MessageBox.Show("Login failed. Please check your username and password.")
        End If
    End Sub

    Private Function IsLoginValid(username As String, password As String) As Boolean
        ' Check if the provided username and password match a user in the database
        Dim query As String = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password"
        Using cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@password", password)
            conn.Open()
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            conn.Close()
            Return count > 0
        End Using
    End Function

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim backform As New Form1()

        ' Show the Form1 (or your main application form)
        backform.Show()

        Me.Hide()
    End Sub
End Class
