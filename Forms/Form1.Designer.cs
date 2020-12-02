
namespace GoalsParser
{
     partial class MainForm
     {
          /// <summary>
          /// Required designer variable.
          /// </summary>
          private System.ComponentModel.IContainer components = null;

          /// <summary>
          /// Clean up any resources being used.
          /// </summary>
          /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
          protected override void Dispose(bool disposing)
          {
               if (disposing && (components != null))
               {
                    components.Dispose();
               }
               base.Dispose(disposing);
          }

          #region Windows Form Designer generated code

          /// <summary>
          /// Required method for Designer support - do not modify
          /// the contents of this method with the code editor.
          /// </summary>
          private void InitializeComponent()
          {
               this.components = new System.ComponentModel.Container();
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
               System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
               System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
               System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
               this.dataGridView1 = new System.Windows.Forms.DataGridView();
               this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
               this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
               this.buttonLoadData = new System.Windows.Forms.Button();
               this.buttonUpdateMain = new System.Windows.Forms.Button();
               this.buttonShowResults = new System.Windows.Forms.Button();
               this.progressBar1 = new System.Windows.Forms.ProgressBar();
               this.tableLayoutPanelSearchFilters = new System.Windows.Forms.TableLayoutPanel();
               this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
               this.textBoxTargetPct1 = new System.Windows.Forms.TextBox();
               this.textBoxTargetPctΧ = new System.Windows.Forms.TextBox();
               this.textBoxTargetPct2 = new System.Windows.Forms.TextBox();
               this.label3 = new System.Windows.Forms.Label();
               this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
               this.labelDataCount = new System.Windows.Forms.Label();
               this.checkBoxShow2 = new System.Windows.Forms.CheckBox();
               this.checkBoxShow1 = new System.Windows.Forms.CheckBox();
               this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
               this.textBoxTargetTziros = new System.Windows.Forms.TextBox();
               this.label1 = new System.Windows.Forms.Label();
               this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
               this.label4 = new System.Windows.Forms.Label();
               this.textBoxOdds1 = new System.Windows.Forms.TextBox();
               this.textBoxOddsX = new System.Windows.Forms.TextBox();
               this.textBoxOdds2 = new System.Windows.Forms.TextBox();
               this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
               this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
               this.tableLayoutPanel1.SuspendLayout();
               this.tableLayoutPanel2.SuspendLayout();
               this.tableLayoutPanelSearchFilters.SuspendLayout();
               this.tableLayoutPanel6.SuspendLayout();
               this.flowLayoutPanel1.SuspendLayout();
               this.tableLayoutPanel3.SuspendLayout();
               this.tableLayoutPanel5.SuspendLayout();
               this.contextMenuStrip1.SuspendLayout();
               this.SuspendLayout();
               // 
               // dataGridView1
               // 
               this.dataGridView1.AllowUserToAddRows = false;
               this.dataGridView1.AllowUserToDeleteRows = false;
               this.dataGridView1.AllowUserToOrderColumns = true;
               resources.ApplyResources(this.dataGridView1, "dataGridView1");
               this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(48)))), ((int)(((byte)(78)))));
               dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
               dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
               dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
               dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
               dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
               dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
               dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
               this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
               this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
               dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
               dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
               dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
               dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
               dataGridViewCellStyle2.Format = "0.00";
               dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
               dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
               dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
               this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
               this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(235)))), ((int)(((byte)(249)))));
               this.dataGridView1.Name = "dataGridView1";
               this.dataGridView1.ReadOnly = true;
               dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
               dataGridViewCellStyle3.Font = new System.Drawing.Font("Franklin Gothic Book", 15F, System.Drawing.FontStyle.Bold);
               this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
               // 
               // tableLayoutPanel1
               // 
               this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(29)))), ((int)(((byte)(63)))));
               resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
               this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
               this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
               this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 3);
               this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelSearchFilters, 1, 1);
               this.tableLayoutPanel1.Name = "tableLayoutPanel1";
               // 
               // tableLayoutPanel2
               // 
               resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
               this.tableLayoutPanel2.Controls.Add(this.buttonLoadData, 0, 0);
               this.tableLayoutPanel2.Controls.Add(this.buttonUpdateMain, 0, 1);
               this.tableLayoutPanel2.Controls.Add(this.buttonShowResults, 0, 3);
               this.tableLayoutPanel2.Name = "tableLayoutPanel2";
               // 
               // buttonLoadData
               // 
               this.buttonLoadData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(48)))), ((int)(((byte)(78)))));
               resources.ApplyResources(this.buttonLoadData, "buttonLoadData");
               this.buttonLoadData.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(155)))), ((int)(((byte)(151)))));
               this.buttonLoadData.ForeColor = System.Drawing.Color.White;
               this.buttonLoadData.Name = "buttonLoadData";
               this.buttonLoadData.UseVisualStyleBackColor = false;
               this.buttonLoadData.Click += new System.EventHandler(this.buttonLoadData_Click);
               // 
               // buttonUpdateMain
               // 
               this.buttonUpdateMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(48)))), ((int)(((byte)(78)))));
               resources.ApplyResources(this.buttonUpdateMain, "buttonUpdateMain");
               this.buttonUpdateMain.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(155)))), ((int)(((byte)(151)))));
               this.buttonUpdateMain.ForeColor = System.Drawing.Color.White;
               this.buttonUpdateMain.Name = "buttonUpdateMain";
               this.buttonUpdateMain.UseVisualStyleBackColor = false;
               this.buttonUpdateMain.Click += new System.EventHandler(this.buttonUpdateMain_Click);
               // 
               // buttonShowResults
               // 
               this.buttonShowResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(48)))), ((int)(((byte)(78)))));
               resources.ApplyResources(this.buttonShowResults, "buttonShowResults");
               this.buttonShowResults.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(155)))), ((int)(((byte)(151)))));
               this.buttonShowResults.ForeColor = System.Drawing.Color.White;
               this.buttonShowResults.Name = "buttonShowResults";
               this.buttonShowResults.UseVisualStyleBackColor = false;
               this.buttonShowResults.Click += new System.EventHandler(this.buttonShowResults_Click);
               // 
               // progressBar1
               // 
               this.tableLayoutPanel1.SetColumnSpan(this.progressBar1, 2);
               resources.ApplyResources(this.progressBar1, "progressBar1");
               this.progressBar1.ForeColor = System.Drawing.Color.Yellow;
               this.progressBar1.Maximum = 10000;
               this.progressBar1.Name = "progressBar1";
               // 
               // tableLayoutPanelSearchFilters
               // 
               resources.ApplyResources(this.tableLayoutPanelSearchFilters, "tableLayoutPanelSearchFilters");
               this.tableLayoutPanelSearchFilters.Controls.Add(this.tableLayoutPanel6, 1, 0);
               this.tableLayoutPanelSearchFilters.Controls.Add(this.flowLayoutPanel1, 0, 0);
               this.tableLayoutPanelSearchFilters.Controls.Add(this.tableLayoutPanel5, 1, 1);
               this.tableLayoutPanelSearchFilters.Name = "tableLayoutPanelSearchFilters";
               // 
               // tableLayoutPanel6
               // 
               resources.ApplyResources(this.tableLayoutPanel6, "tableLayoutPanel6");
               this.tableLayoutPanel6.Controls.Add(this.textBoxTargetPct1, 0, 1);
               this.tableLayoutPanel6.Controls.Add(this.textBoxTargetPctΧ, 1, 1);
               this.tableLayoutPanel6.Controls.Add(this.textBoxTargetPct2, 2, 1);
               this.tableLayoutPanel6.Controls.Add(this.label3, 0, 0);
               this.tableLayoutPanel6.Name = "tableLayoutPanel6";
               // 
               // textBoxTargetPct1
               // 
               resources.ApplyResources(this.textBoxTargetPct1, "textBoxTargetPct1");
               this.textBoxTargetPct1.Name = "textBoxTargetPct1";
               // 
               // textBoxTargetPctΧ
               // 
               resources.ApplyResources(this.textBoxTargetPctΧ, "textBoxTargetPctΧ");
               this.textBoxTargetPctΧ.Name = "textBoxTargetPctΧ";
               // 
               // textBoxTargetPct2
               // 
               resources.ApplyResources(this.textBoxTargetPct2, "textBoxTargetPct2");
               this.textBoxTargetPct2.Name = "textBoxTargetPct2";
               // 
               // label3
               // 
               resources.ApplyResources(this.label3, "label3");
               this.tableLayoutPanel6.SetColumnSpan(this.label3, 3);
               this.label3.ForeColor = System.Drawing.Color.White;
               this.label3.Name = "label3";
               // 
               // flowLayoutPanel1
               // 
               this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(29)))), ((int)(((byte)(63)))));
               this.flowLayoutPanel1.Controls.Add(this.labelDataCount);
               this.flowLayoutPanel1.Controls.Add(this.checkBoxShow2);
               this.flowLayoutPanel1.Controls.Add(this.checkBoxShow1);
               this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel3);
               resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
               this.flowLayoutPanel1.Name = "flowLayoutPanel1";
               this.tableLayoutPanelSearchFilters.SetRowSpan(this.flowLayoutPanel1, 2);
               // 
               // labelDataCount
               // 
               resources.ApplyResources(this.labelDataCount, "labelDataCount");
               this.labelDataCount.ForeColor = System.Drawing.Color.White;
               this.labelDataCount.Name = "labelDataCount";
               // 
               // checkBoxShow2
               // 
               resources.ApplyResources(this.checkBoxShow2, "checkBoxShow2");
               this.checkBoxShow2.ForeColor = System.Drawing.Color.White;
               this.checkBoxShow2.Name = "checkBoxShow2";
               this.checkBoxShow2.UseVisualStyleBackColor = true;
               this.checkBoxShow2.CheckedChanged += new System.EventHandler(this.checkBoxShow2_CheckedChanged);
               // 
               // checkBoxShow1
               // 
               resources.ApplyResources(this.checkBoxShow1, "checkBoxShow1");
               this.checkBoxShow1.ForeColor = System.Drawing.Color.White;
               this.checkBoxShow1.Name = "checkBoxShow1";
               this.checkBoxShow1.UseVisualStyleBackColor = true;
               this.checkBoxShow1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
               // 
               // tableLayoutPanel3
               // 
               resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
               this.tableLayoutPanel3.Controls.Add(this.textBoxTargetTziros, 1, 0);
               this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
               this.tableLayoutPanel3.Name = "tableLayoutPanel3";
               // 
               // textBoxTargetTziros
               // 
               resources.ApplyResources(this.textBoxTargetTziros, "textBoxTargetTziros");
               this.textBoxTargetTziros.Name = "textBoxTargetTziros";
               // 
               // label1
               // 
               resources.ApplyResources(this.label1, "label1");
               this.label1.ForeColor = System.Drawing.Color.White;
               this.label1.Name = "label1";
               // 
               // tableLayoutPanel5
               // 
               resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
               this.tableLayoutPanel5.Controls.Add(this.label4, 0, 0);
               this.tableLayoutPanel5.Controls.Add(this.textBoxOdds1, 0, 1);
               this.tableLayoutPanel5.Controls.Add(this.textBoxOddsX, 1, 1);
               this.tableLayoutPanel5.Controls.Add(this.textBoxOdds2, 2, 1);
               this.tableLayoutPanel5.Name = "tableLayoutPanel5";
               // 
               // label4
               // 
               resources.ApplyResources(this.label4, "label4");
               this.tableLayoutPanel5.SetColumnSpan(this.label4, 3);
               this.label4.ForeColor = System.Drawing.Color.White;
               this.label4.Name = "label4";
               // 
               // textBoxOdds1
               // 
               resources.ApplyResources(this.textBoxOdds1, "textBoxOdds1");
               this.textBoxOdds1.Name = "textBoxOdds1";
               // 
               // textBoxOddsX
               // 
               resources.ApplyResources(this.textBoxOddsX, "textBoxOddsX");
               this.textBoxOddsX.Name = "textBoxOddsX";
               // 
               // textBoxOdds2
               // 
               resources.ApplyResources(this.textBoxOdds2, "textBoxOdds2");
               this.textBoxOdds2.Name = "textBoxOdds2";
               // 
               // dataGridViewTextBoxColumn1
               // 
               this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
               this.dataGridViewTextBoxColumn1.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn2
               // 
               this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
               this.dataGridViewTextBoxColumn2.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn3
               // 
               this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
               this.dataGridViewTextBoxColumn3.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn4
               // 
               this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
               this.dataGridViewTextBoxColumn4.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn5
               // 
               this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
               this.dataGridViewTextBoxColumn5.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn6
               // 
               this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
               this.dataGridViewTextBoxColumn6.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn7
               // 
               this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
               this.dataGridViewTextBoxColumn7.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn8
               // 
               this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
               this.dataGridViewTextBoxColumn8.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn9
               // 
               this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
               this.dataGridViewTextBoxColumn9.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn10
               // 
               this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
               this.dataGridViewTextBoxColumn10.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn11
               // 
               this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
               this.dataGridViewTextBoxColumn11.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn12
               // 
               this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
               this.dataGridViewTextBoxColumn12.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn13
               // 
               this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
               this.dataGridViewTextBoxColumn13.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn14
               // 
               this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
               this.dataGridViewTextBoxColumn14.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn15
               // 
               this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
               this.dataGridViewTextBoxColumn15.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn16
               // 
               this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
               this.dataGridViewTextBoxColumn16.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn17
               // 
               this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
               this.dataGridViewTextBoxColumn17.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn18
               // 
               this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
               this.dataGridViewTextBoxColumn18.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn19
               // 
               this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
               this.dataGridViewTextBoxColumn19.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn20
               // 
               this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
               this.dataGridViewTextBoxColumn20.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn21
               // 
               this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
               this.dataGridViewTextBoxColumn21.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn22
               // 
               this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
               this.dataGridViewTextBoxColumn22.ReadOnly = true;
               // 
               // contextMenuStrip1
               // 
               this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
               this.contextMenuStrip1.Name = "contextMenuStrip1";
               resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
               // 
               // closeToolStripMenuItem
               // 
               this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
               resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
               // 
               // MainForm
               // 
               resources.ApplyResources(this, "$this");
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(29)))), ((int)(((byte)(63)))));
               this.Controls.Add(this.tableLayoutPanel1);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
               this.Name = "MainForm";
               ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
               this.tableLayoutPanel1.ResumeLayout(false);
               this.tableLayoutPanel2.ResumeLayout(false);
               this.tableLayoutPanelSearchFilters.ResumeLayout(false);
               this.tableLayoutPanel6.ResumeLayout(false);
               this.tableLayoutPanel6.PerformLayout();
               this.flowLayoutPanel1.ResumeLayout(false);
               this.flowLayoutPanel1.PerformLayout();
               this.tableLayoutPanel3.ResumeLayout(false);
               this.tableLayoutPanel3.PerformLayout();
               this.tableLayoutPanel5.ResumeLayout(false);
               this.tableLayoutPanel5.PerformLayout();
               this.contextMenuStrip1.ResumeLayout(false);
               this.ResumeLayout(false);

          }

          #endregion

          private System.Windows.Forms.DataGridView dataGridView1;
          private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
          private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
          private System.Windows.Forms.Button buttonLoadData;
          private System.Windows.Forms.Button buttonUpdateMain;
          private System.Windows.Forms.ProgressBar progressBar1;
          private System.Windows.Forms.Button buttonShowResults;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
          private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSearchFilters;
          private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
          private System.Windows.Forms.CheckBox checkBoxShow1;
          private System.Windows.Forms.CheckBox checkBoxShow2;
          private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.TextBox textBoxTargetTziros;
          private System.Windows.Forms.TextBox textBoxTargetPct1;
          private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
          private System.Windows.Forms.TextBox textBoxOdds2;
          private System.Windows.Forms.TextBox textBoxOddsX;
          private System.Windows.Forms.TextBox textBoxOdds1;
          private System.Windows.Forms.Label labelDataCount;
          private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
          private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
          private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
          private System.Windows.Forms.TextBox textBoxTargetPctΧ;
          private System.Windows.Forms.TextBox textBoxTargetPct2;
          private System.Windows.Forms.Label label3;
          private System.Windows.Forms.Label label4;
     }
}

