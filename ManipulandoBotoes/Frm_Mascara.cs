using System.Globalization;
using System.Threading.Tasks;

namespace ManipulandoBotoes
{
    public partial class Frm_Mascara : Form
    {
        public Frm_Mascara()
        {
            InitializeComponent();
        }

        private void Bold(object sender, EventArgs e)
        {

        }
        public enum opcoes
        {
            cep,
            data,
            hora,
            telefone,
            senha,
            moeda
        }
        public opcoes opcaoSelecionada;

        private void Btn_Hora_Click(object sender, EventArgs e)
        {
            Msk_TextBox.UseSystemPasswordChar = false;

            Lbl_Conteudo.Text = "";

            Msk_TextBox.Mask = "00:00";

            Lbl_MascaraAtiva.Text = Msk_TextBox.Mask;

            Msk_TextBox.Text = "";

            Msk_TextBox.Focus();

            Msk_TextBox.RightToLeft = RightToLeft.No;

            opcaoSelecionada = opcoes.hora;



        }

        private void Btn_VerConteudo_Click(object sender, EventArgs e)
        {
            switch (opcaoSelecionada)
            {
                case opcoes.hora:
                    if(!DateTime.TryParseExact(Msk_TextBox.Text, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                    {
                        MessageBox.Show("Por favor, insira um horário válido no formato HH:mm.", "Horário Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Msk_TextBox.Focus();
                    }
                    else
                    {
                        Lbl_Conteudo.Text = Msk_TextBox.Text;
                    }
                    break;
                case opcoes.cep:
                    Lbl_Conteudo.Text = Msk_TextBox.Text;
                    break;
                case opcoes.data:
                    Lbl_Conteudo.Text = Msk_TextBox.Text;
                    break;
                case opcoes.telefone:
                    Lbl_Conteudo.Text = Msk_TextBox.Text;
                    break;
                case opcoes.senha:
                    Lbl_Conteudo.Text = Msk_TextBox.Text;
                    break;
                case opcoes.moeda:
                    Lbl_Conteudo.Text = Msk_TextBox.Text;
                    break;
            }


        }

        private void Btn_CEP_Click(object sender, EventArgs e)
        {
            Msk_TextBox.UseSystemPasswordChar = false;

            Lbl_Conteudo.Text = "";

            Msk_TextBox.Mask = "00000-000";


            Lbl_MascaraAtiva.Text = Msk_TextBox.Mask;

            Msk_TextBox.Text = "";

            Msk_TextBox.Focus();

            Msk_TextBox.RightToLeft = RightToLeft.No;
            
            opcaoSelecionada = opcoes.cep;


        }

        private void Btn_Moeda_Click(object sender, EventArgs e)
        {
            Msk_TextBox.UseSystemPasswordChar = false;

            Lbl_Conteudo.Text = "";

            Msk_TextBox.Mask = "$ 000,000,000.00";

            Lbl_MascaraAtiva.Text = Msk_TextBox.Mask;

            Msk_TextBox.Text = "";

            Msk_TextBox.Focus();
            
            Msk_TextBox.RightToLeft = RightToLeft.Yes;

            opcaoSelecionada = opcoes.moeda;
        }

        private void Btn_Data_Click(object sender, EventArgs e)
        {
            Msk_TextBox.UseSystemPasswordChar = false;

            Lbl_Conteudo.Text = "";

            Msk_TextBox.Mask = "00/00/0000";

            Lbl_MascaraAtiva.Text = Msk_TextBox.Mask;

            Msk_TextBox.Text = "";

            Msk_TextBox.Focus();

            Msk_TextBox.RightToLeft = RightToLeft.No;
        }

        private void Btn_Senha_Click(object sender, EventArgs e)
        {
            Msk_TextBox.UseSystemPasswordChar = true;
            Lbl_Conteudo.Text = "";
            Msk_TextBox.Text = "";
            Msk_TextBox.Mask = "";
            Msk_TextBox.Focus();
            opcaoSelecionada = opcoes.senha;
        }

        private bool IsValidPassword(string password)
        {

            if (password.Length < 8) return false;
            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if ("!@#$%^&*()_-+=<>?".Contains(c)) hasSpecial = true;
            }

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }



        private void Btn_Telefone_Click(object sender, EventArgs e)
        {
            Msk_TextBox.UseSystemPasswordChar = false;

            Lbl_Conteudo.Text = "";

            Msk_TextBox.Mask = " (00) 0000-00000";

            Lbl_MascaraAtiva.Text = Msk_TextBox.Mask;

            Msk_TextBox.Text = "";

            Msk_TextBox.Focus();
            
            Msk_TextBox.RightToLeft = RightToLeft.Yes;

            opcaoSelecionada = opcoes.telefone;



        }

        private void Btn_Confirmar_Click(object sender, EventArgs e)
        {
            string password = Msk_TextBox.Text;

            if (!IsValidPassword(password))
            {
                MessageBox.Show("A senha deve ter pelo menos 8 caracteres, uma letra maiúscula, uma letra minúscula, um número e um caractere especial.");
                Msk_TextBox.Focus();
                return;
            }
        }
    }

}
