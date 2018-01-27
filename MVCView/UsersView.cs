using System;
using System.Windows.Forms;

using WinFormMVC.Controller;
using WinFormMVC.Model;

namespace WinFormMVC.View
{
    public partial class UsersView : Form, IUsersView
    {
        public UsersView()
        {
            InitializeComponent();
        }

        UsersController _controller;

        #region Events raised  back to controller

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            this._controller.AddNewUser();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            this._controller.RemoveUser();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            this._controller.Save();
        }

        private void GrdUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.grdUsers.SelectedItems.Count > 0)
                this._controller.SelectedUserChanged(this.grdUsers.SelectedItems[0].Text);
        }


        #endregion

        #region ICatalogView implementation

        public void SetController(UsersController controller)
        {
            _controller = controller;
        }

        public void ClearGrid()
        {
            // Define columns in grid
            this.grdUsers.Columns.Clear();

            this.grdUsers.Columns.Add("Id",          150,  HorizontalAlignment.Left);
            this.grdUsers.Columns.Add("First Name",  150,  HorizontalAlignment.Left);
            this.grdUsers.Columns.Add("Lastst Name", 150,  HorizontalAlignment.Left);
            this.grdUsers.Columns.Add("Department",  150,  HorizontalAlignment.Left);
            this.grdUsers.Columns.Add("Sex",         50,   HorizontalAlignment.Left);

            // Add rows to grid
            this.grdUsers.Items.Clear();
        }

        public void AddUserToGrid(User user)
        {
            ListViewItem parent = grdUsers.Items.Add(user.Id);
            parent.SubItems.Add(user.FirstName);
            parent.SubItems.Add(user.LastName);
            parent.SubItems.Add(user.Department);
            parent.SubItems.Add(Enum.GetName(typeof(User.SexOfPerson), user.Sex));
        }

        public void UpdateGridWithChangedUser(User user)
        {
            ListViewItem rowToUpdate = null;

            foreach (ListViewItem row in this.grdUsers.Items)
            {
                if (row.Text == user.Id)
                {
                    rowToUpdate = row;
                }
            }

            if (rowToUpdate == null) return;

            rowToUpdate.Text = user.Id;
            rowToUpdate.SubItems[1].Text = user.FirstName;
            rowToUpdate.SubItems[2].Text = user.LastName;
            rowToUpdate.SubItems[3].Text = user.Department;
            rowToUpdate.SubItems[4].Text = Enum.GetName(typeof(User.SexOfPerson), user.Sex);
        }

        public void RemoveUserFromGrid(User user)
        {

            ListViewItem rowToRemove = null;

            foreach (ListViewItem row in this.grdUsers.Items)
            {
                if (row.Text == user.Id)
                {
                    rowToRemove = row;
                }
            }

            if (rowToRemove != null)
            {
                this.grdUsers.Items.Remove(rowToRemove);
                this.grdUsers.Focus();
            }
        }

        public string GetIdOfSelectedUserInGrid()
        {
            if (this.grdUsers.SelectedItems.Count > 0)
                return this.grdUsers.SelectedItems[0].Text;
            else
                return "";
        }

        public void SetSelectedUserInGrid(User user)
        {
            foreach (ListViewItem row in this.grdUsers.Items)
            {
                if (row.Text == user.Id)
                {
                    row.Selected = true;
                }
            }
        }

        public string FirstName 
        {
            get { return this.txtFirstName.Text; }
            set { this.txtFirstName.Text = value; }
        }

        public string LastName 
        {
            get { return this.txtLastName.Text; }
            set { this.txtLastName.Text = value; }
        }

        public string ID
        {
            get { return this.txtID.Text; }
            set { this.txtID.Text = value; }
        }


        public string Department 
        {
            get { return this.txtDepartment.Text; }
            set { this.txtDepartment.Text = value; }
        }

        public User.SexOfPerson Sex
        {
            get
            {
                if (this.rdMale.Checked)
                    return User.SexOfPerson.Male;
                else
                    return User.SexOfPerson.Female;
            }
            set
            {
                if (value == User.SexOfPerson.Male)
                    this.rdMale.Checked = true;
                else
                    this.rdFamele.Checked = true;
            }
        }

        public bool CanModifyId
        {
            get { return this.txtID.Enabled; }
            set { this.txtID.Enabled = value; }
        }

        #endregion
    }
}
