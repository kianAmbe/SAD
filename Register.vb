Imports MySql.Data.MySqlClient

Public Class Register
    Dim conn As MySqlConnection
    Dim connectionString As String

    Public Sub New()
        InitializeComponent()
        ' Initialize the connection string with your MySQL database details
        connectionString = "Server=localhost;Database=dbsad;Uid=root;Pwd=;"
        conn = New MySqlConnection(connectionString)
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        ' Get user input from the form
        Dim username As String = UsernameTextBox.Text
        Dim password As String = PasswordTextBox.Text
        Dim email As String = EmailTextBox.Text

        ' Perform basic input validation (you should add more extensive validation)
        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Or String.IsNullOrEmpty(email) Then
            MessageBox.Show("Please fill in all fields.")
            Return
        End If

        ' Check if the username or email is already in use
        If IsUsernameOrEmailInUse(username, email) Then
            MessageBox.Show("Username or email is already in use. Please choose another one.")
            Return
        End If

        ' Insert user data into the 'users' table
        Dim query As String = "INSERT INTO users (username, password, email) VALUES (@username, @password, @email)"

        Using cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@password", password)
            cmd.Parameters.AddWithValue("@email", email)

            Try
                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
                MessageBox.Show("Registration successful")

                ' Open Form1 (or your main application form) and close the current registration form
                Dim mainForm As New Form1()
                mainForm.Show()
                Me.Close()

            Catch ex As Exception
                MessageBox.Show("Registration failed: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Function IsUsernameOrEmailInUse(username As String, email As String) As Boolean
        ' Check if the provided username or email is already in use in the database
        Dim query As String = "SELECT COUNT(*) FROM users WHERE username = @username OR email = @email"
        Using cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@email", email)
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

