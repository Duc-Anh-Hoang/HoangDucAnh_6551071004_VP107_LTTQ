using System.Text.RegularExpressions;
using _6551071004_VP107.Models;
using Microsoft.EntityFrameworkCore;

namespace _6551071004_VP107
{
    public partial class Form1 : Form
    {
        private DuLieuContext db = new DuLieuContext();
        private string _originalMa = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void SetButtonState(bool isRowSelected)
        {
            btnThem.Enabled = !isRowSelected;
            btnSua.Enabled = isRowSelected;
            btnXoa.Enabled = isRowSelected;
            btnThoat.Enabled = true;
        }

        private void ResetForm()
        {
            _originalMa = "";
            txtMa.Clear();
            txtTen.Clear();
            txtTinChi.Text = "";
            txtMa.ReadOnly = false;
            txtMa.Enabled = true;
            SetButtonState(false);
            txtMa.Focus();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var list = await db.MonHoc.Select(mh => new
                {
                    mh.MaMonHoc,
                    mh.TenMonHoc,
                    mh.SoTinChi
                }).ToListAsync();

                dgvDanhSach.DataSource = null;
                dgvDanhSach.DataSource = list;
                if (dgvDanhSach.Columns["MaMonHoc"] is DataGridViewColumn colMa)
                    colMa.HeaderText = "Mã Môn Học";
                if (dgvDanhSach.Columns["TenMonHoc"] is DataGridViewColumn colTen)
                    colTen.HeaderText = "Tên môn học";
                if (dgvDanhSach.Columns["SoTinChi"] is DataGridViewColumn colTC)
                    colTC.HeaderText = "Số tín chỉ";
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            dgvDanhSach.ReadOnly = true;
            dgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSach.MultiSelect = false;
            dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSach.AllowUserToAddRows = false;
            await LoadDataAsync();
        }

        private async void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDanhSach.CurrentRow != null)
            {
                string ma = dgvDanhSach.CurrentRow.Cells["MaMonHoc"].Value?.ToString() ?? "";
                if (_originalMa == ma && btnSua.Enabled)
                {
                    ResetForm();
                    return;
                }
                var mh = await db.MonHoc.FindAsync(ma);
                if (mh != null)
                {
                    _originalMa = mh.MaMonHoc;
                    txtMa.ReadOnly = false;
                    txtMa.Enabled = true;
                    txtMa.Text = mh.MaMonHoc;
                    txtTen.Text = mh.TenMonHoc;
                    txtTinChi.Text = mh.SoTinChi ?? "0";
                    SetButtonState(true);
                }
            }
            else
            {
                ResetForm();
            }
        }

        private void txtTinChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            // Chặn nhập '0' khi ô đang rỗng (tránh số như 00, 033...)
            if (e.KeyChar == '0' && txtTinChi.Text.Length == 0)
            {
                e.Handled = true;
            }
        }

        private bool ValidateInput(bool isAdding)
        {
            string ma = txtMa.Text.Trim();
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Mã môn học không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMa.Focus();
                return false;
            }
            if (!Regex.IsMatch(ma, @"^[a-zA-Z0-9]{1,10}$"))
            {
                MessageBox.Show("Mã môn học phải từ 1-10 ký tự và không chứa ký tự đặc biệt!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMa.Focus();
                return false;
            }
            if ((isAdding || ma != _originalMa) && db.MonHoc.Any(x => x.MaMonHoc == ma))
            {
                MessageBox.Show("Mã này đã tồn tại trong CSDL!", "Trùng khóa chính", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMa.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Tên môn học không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return false;
            }
            if (!int.TryParse(txtTinChi.Text.Trim(), out int soTinChi) || soTinChi < 1)
            {
                MessageBox.Show("Số tín chỉ phải là số nguyên dương!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTinChi.Focus();
                return false;
            }
            return true;
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(isAdding: true)) return;
            try
            {
                var mh = new MonHoc
                {
                    MaMonHoc = txtMa.Text.Trim(),
                    TenMonHoc = txtTen.Text.Trim(),
                    SoTinChi = int.Parse(txtTinChi.Text.Trim()).ToString(),
                };
                db.MonHoc.Add(mh);
                await db.SaveChangesAsync();
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_originalMa))
            {
                MessageBox.Show("Vui lòng chọn một dòng trên bảng để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput(isAdding: false)) return;
            try
            {
                string newMa = txtMa.Text.Trim();
                string newTen = txtTen.Text.Trim();
                string newTC = int.Parse(txtTinChi.Text.Trim()).ToString();

                var mhOld = await db.MonHoc.FindAsync(_originalMa);
                if (mhOld != null)
                {
                    if (newMa != _originalMa)
                    {
                        using var transaction = await db.Database.BeginTransactionAsync();
                        try
                        {
                            db.MonHoc.Remove(mhOld);
                            await db.SaveChangesAsync();
                            var mhNew = new MonHoc
                            {
                                MaMonHoc = newMa,
                                TenMonHoc = newTen,
                                SoTinChi = newTC
                            };
                            db.MonHoc.Add(mhNew);
                            await db.SaveChangesAsync();
                            await transaction.CommitAsync();
                        }
                        catch
                        {
                            await transaction.RollbackAsync();
                            throw;
                        }
                    }
                    else
                    {
                        mhOld.TenMonHoc = newTen;
                        mhOld.SoTinChi = newTC;
                        await db.SaveChangesAsync();
                    }
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_originalMa))
            {
                MessageBox.Show("Vui lòng chọn một dòng trên bảng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa '{txtTen.Text}' (Mã: {_originalMa}) không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var mh = await db.MonHoc.FindAsync(_originalMa);
                    if (mh != null)
                    {
                        db.MonHoc.Remove(mh);
                        await db.SaveChangesAsync();
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Bạn có muốn thoát không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
