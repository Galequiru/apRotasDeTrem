using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Gabriel Leonardo Quimbayo Ruiz 22132
// Pietro Gutiérrez García-Urrutia 22148

namespace apRotasDeTrem
{
    public partial class Renfe : Form
    {
        private Arvore<Cidade> cidades;
        private Arvore<Caminho> arvoreCaminho;
        private Cidade cidadeAtiva = null;
        private bool adicionando = false, alterando = false, adicionandoCaminho = false, alterandoCaminho = false;
        DataGridViewRow selectedRow = null;
        string novoNome = "";
        const string rota = "Z:\\4o semestre\\EstruturaDados2\\apRotasDeTrem\\";

        public Renfe()
        {
            InitializeComponent();
            cidades = new Arvore<Cidade>(rota + "cidades.dat"); //lê o arquivo de cidades e as coloca na arvore

            arvoreCaminho = new Arvore<Caminho>(rota + "caminhos.dat");

            var caminhos = arvoreCaminho.ToList();
            foreach (Caminho caminho in caminhos) 
            {
                if (cidades.Existe(new Cidade() {
                    Nome = caminho.CidadeOrigem
                }))
                {
                    cidades.Atual.Info.Caminhos.Add(caminho);
                }
            }
        }

        private void imgArvore_Paint(object sender, PaintEventArgs e) //desenha a arvore
        {
            cidades.Desenhar(imgArvore.Width / 2, 0, e.Graphics, incremento: 1.2, comprimento: 200);
        }

        private void tpArvore_Enter(object sender, EventArgs e)
        {
            lbMensagem.Text = "Desenhando árvore de cidades, o número entre parênteses representa o número de rotas que se originam da cidade";
        }

        private void tpCidades_Enter(object sender, EventArgs e)
        {
            lbMensagem.Text = "Gerenciando cidades e caminhos que se originam delas";
        }

        private void imgPeninsulaIberica_Paint(object sender, PaintEventArgs e)
        {
            var listaCidades = cidades.ToList();    //cria uma lista das cidades para um manejo mais rápido dos dados

            int width  = imgPeninsulaIberica.Width,
                height = imgPeninsulaIberica.Height;
            Graphics g = e.Graphics;
            Brush pincel = new SolidBrush(Color.Blue);

            foreach (Cidade cidade in listaCidades) //vai desenhar um ponto azul nas coordenadas de cada cidade cadastrada
            {
                float x = (float)(width * cidade.CoordenadaX), 
                      y = (float)(height * cidade.CoordenadaY);
                g.FillEllipse(pincel, x-2, y-2, 5, 5);
            }
            if (cidadeAtiva != null)    //se houver alguma cidade escolhida como ativa, um ponto vermelho apontará sua localizão
            {
                g.FillEllipse(new SolidBrush(Color.Red),
                    (float)(width * cidadeAtiva.CoordenadaX)-3,
                    (float)(height * cidadeAtiva.CoordenadaY)-3,
                    7, 7);
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            string novaCidade = txtNome.Text.Trim();    //pega o nome digitado pelo usuário e tira os espacos adicionais

            if (cidades.Existe(new Cidade { //se houver uma cidade na árvore com esse nome cadastrado
                Nome = novaCidade
            }))
            {
                MessageBox.Show("Já existe uma cidade cadastrada com esse nome");
                ExibirCidade(cidades.Atual.Info); //exibe a cidade digitada pelo usuário
            }
            else
            if (novaCidade.Length > 0) //se um nome válido foi digitado
            {
                DesativarBotoes();
                lbMensagem.Text = "Clique no mapa a localização da nova cidade, botão direito para cancelar";
                adicionando = true; //e anuncia que uma nova cidade esta sendo adicionada
            }
            else
                MessageBox.Show("Digite o nome da nova cidade antes");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (cidadeAtiva == null)
            {
                MessageBox.Show("Escolha uma cidade primeiro \nFaça isso inserindo o nome de uma cidade e clicando em 'exibir'");
                return;
            }
            novoNome = Prompt.ShowDialog("Escreva o novo nome da cidade (aperte X para não alterar o nome)", "Alterando cidade");

            if (novoNome == null) novoNome = cidadeAtiva.Nome; //se for apertado o X no prompt, o nome não vai mudar
            else    //o nome vai ser alterado, então temos que validá-lo
            {
                novoNome = novoNome.Trim();    //tira os espaços adicionais digitados se o nome for ser alterado
                if (novoNome.Length > 0)
                {
                    if (cidades.Existe(new Cidade
                    {           
                        Nome = novoNome //se houver uma cidade na árvore com esse nome cadastrado
                    }))
                    {
                        MessageBox.Show("Já existe uma cidade cadastrada com esse nome");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Novo nome inválido");
                    return;
                }
            }
            DesativarBotoes();
            lbMensagem.Text = "Clique no mapa a nova localização da cidade, botão esquerdo para não mudar, scroll para cancelar";
            alterando = true; //anuncia que uma nova cidade esta sendo adicionada
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            string nomeCidade = txtNome.Text.Trim();    //pega o nome digitado pelo usuário e tira os espacos adicionais

            if (cidades.Existe(new Cidade { //se houver uma cidade na árvore com esse nome cadastrado
                Nome = nomeCidade
            }))
            {
                ExibirCidade(cidades.Atual.Info); //essa cidade se tornará a cidade escolhida
            }
            else
            {
                MessageBox.Show("Não existe cidade cadastrada com esse nome \nMaiúsculas e minusculas fazem diferença");
                ExibirCidade(null);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (cidadeAtiva == null)
            {
                MessageBox.Show("Escolha uma cidade primeiro \nFaça isso inserindo o nome de uma cidade e clicando em 'exibir'");
                return;
            }
            if (MessageBox.Show("Tem certeza que deseja remover esta cidade?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cidades.Excluir(cidadeAtiva); //a cidade é excluída da árvore
                ExibirCidade(null);
            }
        }

        private void btnIncluirCaminho_Click(object sender, EventArgs e)
        {
            if (cidadeAtiva != null)
            {
                adicionandoCaminho = true;
                dgvRotas.Rows.Add(cidadeAtiva.Nome);
                DataGridViewRow novoCaminho = dgvRotas.Rows[dgvRotas.Rows.Count - 1]; // pega a nova(última) linha do dgv

                int clnDestinoIndex = 1;
                int clnDistanciaIndex = 2;
                int clnTempoIndex = 3;
                novoCaminho.Cells[clnDestinoIndex].ReadOnly = false; // torna falso o readOnly da coluna de Destino
                novoCaminho.Cells[clnDistanciaIndex].ReadOnly = false;
                novoCaminho.Cells[clnTempoIndex].ReadOnly = false;

                btnIncluirCaminho.Enabled = false;
                btnAlterarCaminho.Enabled = false;
                btnExcluirCaminho.Enabled = false;
                txtNome.Enabled = false;
                btnIncluir.Enabled = false;
                btnExibir.Enabled = false;
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Escolha uma cidade de origem primeiro \nFaça isso inserindo o nome de uma cidade e clicando em 'exibir'");
                return;
            }
        }


        private void btnAlterarCaminho_Click(object sender, EventArgs e)
        {
            if (cidadeAtiva != null)
            {
                alterandoCaminho = true;
                if (dgvRotas.SelectedCells.Count > 0)
                {
                    int selectedRowIndex = dgvRotas.SelectedCells[0].RowIndex;
                    selectedRow = dgvRotas.Rows[selectedRowIndex]; // Store the selected row

                    int clnDestinoIndex = 1;
                    int clnDistanciaIndex = 2;
                    int clnTempoIndex = 3;
                    selectedRow.Cells[clnDestinoIndex].ReadOnly = false;
                    selectedRow.Cells[clnDistanciaIndex].ReadOnly = false;
                    selectedRow.Cells[clnTempoIndex].ReadOnly = false;

                    btnIncluirCaminho.Enabled = false;
                    btnAlterarCaminho.Enabled = false;
                    btnExcluirCaminho.Enabled = false;
                    txtNome.Enabled = false;
                    btnIncluir.Enabled = false;
                    btnExibir.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnAlterar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Selecione a linha que deseja alterar.");
                }
            }
            else
            {
                MessageBox.Show("Escolha uma cidade de origem primeiro \nFaça isso inserindo o nome de uma cidade e clicando em 'exibir'");
                return;
            }
        }

        private void btnSalvarCaminho_Click(object sender, EventArgs e)
        {
            if (adicionandoCaminho)
            {
                DataGridViewRow novoCaminho = dgvRotas.Rows[dgvRotas.Rows.Count - 1];
                int clnDestinoIndex = 1;
                int clnDistanciaIndex = 2;
                int clnTempoIndex = 3;

                string novoDestino = novoCaminho.Cells[clnDestinoIndex].Value.ToString();
                string novaDistancia = novoCaminho.Cells[clnDistanciaIndex].Value.ToString();
                string novoTempo = novoCaminho.Cells[clnTempoIndex].Value.ToString();

                if (!string.IsNullOrEmpty(novoDestino) && !string.IsNullOrEmpty(novaDistancia) && !string.IsNullOrEmpty(novoTempo))
                {
                    if (cidades.Existe(new Cidade
                    { //se houver uma cidade na árvore com esse nome cadastrado
                        Nome = novoDestino
                    }))
                    {
                        int distancia;
                        if (int.TryParse(novaDistancia, out distancia))
                        {
                            int tempo;
                            if (int.TryParse(novoTempo, out tempo))
                            {
                                Caminho novoCaminhoObj = new Caminho()
                                {
                                    CidadeOrigem = cidadeAtiva.Nome,
                                    CidadeDestino = novoDestino,
                                    Distancia = distancia,
                                    Tempo = tempo
                                };

                                cidadeAtiva.Caminhos.Add(novoCaminhoObj);
                                UpdateCaminhosDataGridView();

                                btnIncluirCaminho.Enabled = true;
                                btnAlterarCaminho.Enabled = true;
                                btnExcluirCaminho.Enabled = true;
                                txtNome.Enabled = true;
                                btnIncluir.Enabled = true;
                                btnExibir.Enabled = true;
                                btnExcluir.Enabled = true;
                                btnAlterar.Enabled = true;

                                adicionandoCaminho = false;
                            }
                            else
                            {
                                MessageBox.Show("Por favor, insira um valor válido para o tempo.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, insira um valor válido para a distância.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, insira uma cidade já existente para destino.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, preencha todos os campos antes de adicionar a rota.");
                }

            }
            if (alterandoCaminho && selectedRow != null)
            {
                if (alterandoCaminho && selectedRow != null)
                {
                    // Obtém os valores da célula selecionada para destino, distância e tempo
                    int clnDestinoIndex = 1;
                    int clnDistanciaIndex = 2;
                    int clnTempoIndex = 3;

                    string novoDestino = selectedRow.Cells[clnDestinoIndex].Value.ToString();
                    string novaDistancia = selectedRow.Cells[clnDistanciaIndex].Value.ToString();
                    string novoTempo = selectedRow.Cells[clnTempoIndex].Value.ToString();

                    if (!string.IsNullOrEmpty(novoDestino) && !string.IsNullOrEmpty(novaDistancia) && !string.IsNullOrEmpty(novoTempo))
                    {
                        if (cidades.Existe(new Cidade { Nome = novoDestino }))
                        {
                            int distancia, tempo;

                            // Tenta converter os valores para inteiros
                            if (int.TryParse(novaDistancia, out distancia) && int.TryParse(novoTempo, out tempo))
                            {
                                // Atualiza os valores do caminho na cidade ativa
                                Caminho caminhoExistente = cidadeAtiva.Caminhos.Find(c => c.CidadeDestino.Equals(novoDestino));

                                if (caminhoExistente != null)
                                {
                                    caminhoExistente.Distancia = distancia;
                                    caminhoExistente.Tempo = tempo;
                                }

                                // Atualiza os valores na célula selecionada
                                selectedRow.Cells[clnDistanciaIndex].Value = distancia;
                                selectedRow.Cells[clnTempoIndex].Value = tempo;

                                // Restaura o estado original dos controles e variáveis
                                btnIncluirCaminho.Enabled = true;
                                btnAlterarCaminho.Enabled = true;
                                btnExcluirCaminho.Enabled = true;
                                txtNome.Enabled = true;
                                btnIncluir.Enabled = true;
                                btnExibir.Enabled = true;
                                btnExcluir.Enabled = true;
                                btnAlterar.Enabled = true;

                                selectedRow = null;
                                alterandoCaminho = false;
                            }
                            else
                            {
                                MessageBox.Show("Por favor, insira valores válidos para distância e tempo.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, insira uma cidade já existente para destino.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, preencha todos os campos antes de adicionar a rota.");
                    }
                }
                else
                {
                    MessageBox.Show("Nenhuma linha selecionada para alteração.");
                }
            }
        }

        

        private void UpdateCaminhosDataGridView()
        {
            if (cidadeAtiva != null)
            {
                dgvRotas.Rows.Clear(); // Clear existing rows in the DataGridView
                foreach (Caminho caminho in cidadeAtiva.Caminhos)
                {
                    if (caminho.CidadeOrigem.Equals(cidadeAtiva.Nome))
                    {
                        // Add a new row to the DataGridView for each path
                        dgvRotas.Rows.Add(caminho.CidadeOrigem, caminho.CidadeDestino, caminho.Distancia, caminho.Tempo);
                    }
                }   
            }
        }

        private void ExibirCidade(Cidade cidade) 
        {
            cidadeAtiva = cidade;

            dgvRotas.Rows.Clear();
            if (cidadeAtiva != null)
            {
                txtNome.Text = cidadeAtiva.Nome;
                txtX.Value = (decimal)cidadeAtiva.CoordenadaX;
                txtY.Value = (decimal)cidadeAtiva.CoordenadaY;
                foreach (Caminho caminho in cidadeAtiva.Caminhos)
                {
                    if (caminho.CidadeOrigem.Equals(cidadeAtiva.Nome))
                    {
                        // Add a new row to the DataGridView for each path
                        dgvRotas.Rows.Add(caminho.CidadeOrigem, caminho.CidadeDestino, caminho.Distancia, caminho.Tempo);
                    }
                }
            }
            else
            {
                txtNome.Text = "";
                txtX.Value = 0;
                txtY.Value = 0;
            }
            imgPeninsulaIberica.Invalidate();
        }

        private void DesativarBotoes()
        {
            btnAlterar.Enabled = false; //desativa os botões de gerenciamento de cidade
            btnExcluir.Enabled = false;
            btnExibir.Enabled = false;
            btnIncluir.Enabled = false;

            txtNome.ReadOnly = true;  //impede a alteração do nome da cidade

            btnIncluirCaminho.Enabled = false; //desativa os botões de gerenciamento de caminhos
            btnExcluirCaminho.Enabled = false;
            btnAlterarCaminho.Enabled = false;
            btnSalvarCaminho.Enabled = false;
        }

        private void ReativarBotoes()
        {
            btnAlterar.Enabled = true; //desativa os botões de gerenciamento de cidade
            btnExcluir.Enabled = true;
            btnExibir.Enabled = true;
            btnIncluir.Enabled = true;

            txtNome.ReadOnly = false;  //impede a alteração do nome da cidade

            btnIncluirCaminho.Enabled = true; //desativa os botões de gerenciamento de caminhos
            btnExcluirCaminho.Enabled = true;
            btnAlterarCaminho.Enabled = true;
            btnSalvarCaminho.Enabled = true;
        }

        private void imgPeninsulaIberica_MouseClick(object sender, MouseEventArgs e)
        {
            if (adicionando)
            {
                if (e.Button == MouseButtons.Right)
                {
                    //nenhuma cidade é adicionada
                    ExibirCidade(null);
                }
                else
                {
                    double x = (double)decimal.Divide(e.X, imgPeninsulaIberica.Width);
                    double y = (double)decimal.Divide(e.Y, imgPeninsulaIberica.Height);
                    Cidade novaCidade = new Cidade(txtNome.Text, x, y);
                    cidades.Incluir(novaCidade);
                    ExibirCidade(novaCidade);
                }
                ReativarBotoes();
                lbMensagem.Text = "Gerenciando cidades e caminhos que se originam delas";
                adicionando = false; //e anuncia que a nova cidade foi adicionada
            }

            if (alterando)
            {   
                if (e.Button == MouseButtons.Middle)
                {
                    //nenhuma cidade é alterada
                    ExibirCidade(cidadeAtiva);
                }
                else
                {
                    double novoX = (double)decimal.Divide(e.X, imgPeninsulaIberica.Width);
                    double novoY = (double)decimal.Divide(e.Y, imgPeninsulaIberica.Height);

                    if (e.Button == MouseButtons.Right) //o usuário não quis mudar as coordenadas da cidade
                    {
                        novoX = cidadeAtiva.CoordenadaX;
                        novoY = cidadeAtiva.CoordenadaY;
                    }

                    List<Caminho> caminhosCidade = cidadeAtiva.Caminhos;
                    cidades.Excluir(cidadeAtiva);   //a cidade é excluida e reincluida 
                                                    //para que em futuras pesquisas o nome
                    Cidade cidade = new Cidade()    //ser diferente não cause nenhum problema
                    {
                        Nome = novoNome, CoordenadaX = novoX, CoordenadaY = novoY, Caminhos = caminhosCidade
                    };
                    cidades.Incluir(cidade); //coloca o ponteiro na cidade que queremos alterar

                    ExibirCidade(cidades.Atual.Info);
                }
                ReativarBotoes();
                lbMensagem.Text = "Gerenciando cidades e caminhos que se originam delas";
                alterando = false; //e anuncia que cidade foi alterada
            }
        }

        private void Renfe_FormClosing(object sender, FormClosingEventArgs e)
        {
            cidades.GravarArquivoDeRegistros(rota + "cidades.dat");
            arvoreCaminho.GravarArquivoDeRegistros(rota + "caminhos.dat");
        }
    }
}
