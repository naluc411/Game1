Public Class Form1
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles enemy3.Click

    End Sub
    Dim r As New Random
    Sub randmove(p As PictureBox)
        Dim x As Integer
        Dim y As Integer
        MoveTo(p, x, y)
        x = r.Next(-10, 11)
        y = r.Next(-10, 11)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Move(enemy3, 5, 5)
        chase(enemy3)
        randmove(enemy3)
    End Sub
    Sub Move(p As PictureBox, x As Integer, y As Integer)
        p.Location = New Point(p.Location.X + x, p.Location.Y + y)



    End Sub

    Private Sub picturebox1_click(sender As Object, e As EventArgs) Handles PictureBox1.Click
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                MoveTo(PictureBox1, 0, -7)
            Case Keys.Down
                MoveTo(PictureBox1, 0, 7)
            Case Keys.Left
                MoveTo(PictureBox1, -7, 0)
            Case Keys.Right
                MoveTo(PictureBox1, 7, 0)
            Case 2

            Case Keys.R
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipX)

            Case Else

        End Select
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles enemy3.Click

    End Sub

    Private Sub PictureBox3_Click_1(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click

    End Sub



    Private Sub Wall_Click(sender As Object, e As EventArgs) Handles Wall.Click

    End Sub

    Private Sub wall17_Click(sender As Object, e As EventArgs) Handles wall17.Click

    End Sub


    Sub follow(p As PictureBox)
        Static headstart As Integer
        Static c As New Collection
        c.Add(PictureBox1.Location)
        headstart = headstart + 1
        If headstart > 10 Then
            p.Location = c.Item(1)
            c.Remove(1)
        End If
    End Sub

    Public Sub chase(p As PictureBox)
        Dim x, y As Integer
        If p.Location.X > PictureBox1.Location.X Then
            x = -5
        Else
            x = 5
        End If
        MoveTo(p, x, 0)
        If p.Location.Y < PictureBox1.Location.Y Then
            y = 5
        Else
            y = -5
        End If
        MoveTo(p, x, y)
    End Sub



    Function Collision(p As PictureBox, t As String)
        Dim col As Boolean

        For Each c In Controls
            Dim obj As Control
            obj = c
            If p.Bounds.IntersectsWith(obj.Bounds) And obj.Name.ToUpper.Contains(t.ToUpper) Then
                col = True
            End If
        Next
        Return col
    End Function
    'Return true or false if moving to the new location is clear of objects ending with t
    Function IsClear(p As PictureBox, distx As Integer, disty As Integer, t As String) As Boolean
        Dim b As Boolean

        p.Location += New Point(distx, disty)
        b = Not Collision(p, t)
        p.Location -= New Point(distx, disty)
        Return b
    End Function
    'Moves and object (won't move onto objects containing  "wall" and shows green if object ends with "win"
    Sub MoveTo(p As PictureBox, distx As Integer, disty As Integer)
        If IsClear(p, distx, disty, "wall") Then
            p.Location += New Point(distx, disty)
        End If

        If p.Name = "PictureBox" And Collision(p, "WIN") Then
            Me.BackColor = Color.Green
            Return
        Else
            Me.BackColor = Color.Black
        End If



    End Sub


End Class

