namespace VolCenterProject
{
    public partial class FormEventsView : Form
    {
        public Models.User CurrentUser { get; private set; }
        public bool isGuest { get; private set; }

        public FormEventsView(Models.User currentUser, bool isGuest)
        {
            InitializeComponent();

            var colEventName = new DataGridViewTextBoxColumn();
            colEventName.Name = "colEventName";
            colEventName.HeaderText = "Мероприятие";
            colEventName.Width = 200;
            colEventName.FillWeight = 20;

            var colCategory = new DataGridViewTextBoxColumn();
            colCategory.Name = "colCategory";
            colCategory.HeaderText = "Категория";
            colCategory.Width = 100;
            colCategory.FillWeight = 10;

            var colDate = new DataGridViewTextBoxColumn();
            colDate.Name = "colDate";
            colDate.HeaderText = "Дата";
            colDate.Width = 100;
            colDate.FillWeight = 10;

            var colLocation = new DataGridViewTextBoxColumn();
            colLocation.Name = "colLocation";
            colLocation.HeaderText = "Место";
            colLocation.Width = 150;
            colLocation.FillWeight = 15;

            var colVolunteers = new DataGridViewTextBoxColumn();
            colVolunteers.Name = "colVolunteers";
            colVolunteers.HeaderText = "Требуется";
            colVolunteers.Width = 80;
            colVolunteers.FillWeight = 8;
            colVolunteers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var colRegistered = new DataGridViewTextBoxColumn();
            colRegistered.Name = "colRegistered";
            colRegistered.HeaderText = "Записано";
            colRegistered.Width = 80;
            colRegistered.FillWeight = 8;
            colRegistered.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var colCoordinator = new DataGridViewTextBoxColumn();
            colCoordinator.Name = "colCoordinator";
            colCoordinator.HeaderText = "Координатор";
            colCoordinator.Width = 150;
            colCoordinator.FillWeight = 15;

            var colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "colStatus";
            colStatus.HeaderText = "Статус";
            colStatus.Width = 100;
            colStatus.FillWeight = 10;
            colStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvEvents.Columns.AddRange(
            [
                colEventName, colCategory, colDate, colLocation,
                colVolunteers, colRegistered, colCoordinator, colStatus
            ]);

            dgvEvents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEvents.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            CurrentUser = currentUser;
            this.isGuest = isGuest;

            lbUserName.Text = isGuest ? "Гость" : (CurrentUser?.FullName ?? "Гость");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }
}
