
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
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
               this.dataGridView1 = new System.Windows.Forms.DataGridView();
               this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
               this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
               this.buttonLoadData = new System.Windows.Forms.Button();
               this.buttonUpdateMain = new System.Windows.Forms.Button();
               this.buttonUpdate1 = new System.Windows.Forms.Button();
               this.buttonUpdate2 = new System.Windows.Forms.Button();
               this.button1 = new System.Windows.Forms.Button();
               ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
               this.tableLayoutPanel1.SuspendLayout();
               this.tableLayoutPanel2.SuspendLayout();
               this.SuspendLayout();
               // 
               // dataGridView1
               // 
               this.dataGridView1.AllowUserToAddRows = false;
               this.dataGridView1.AllowUserToDeleteRows = false;
               this.dataGridView1.AllowUserToOrderColumns = true;
               this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
               this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
               this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
               resources.ApplyResources(this.dataGridView1, "dataGridView1");
               this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(235)))), ((int)(((byte)(249)))));
               this.dataGridView1.Name = "dataGridView1";
               this.dataGridView1.ReadOnly = true;
               // 
               // tableLayoutPanel1
               // 
               resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
               this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
               this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
               this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
               this.tableLayoutPanel1.Name = "tableLayoutPanel1";
               // 
               // tableLayoutPanel2
               // 
               resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
               this.tableLayoutPanel2.Controls.Add(this.buttonLoadData, 0, 0);
               this.tableLayoutPanel2.Controls.Add(this.buttonUpdateMain, 0, 1);
               this.tableLayoutPanel2.Controls.Add(this.buttonUpdate1, 0, 2);
               this.tableLayoutPanel2.Controls.Add(this.buttonUpdate2, 0, 3);
               this.tableLayoutPanel2.Name = "tableLayoutPanel2";
               // 
               // buttonLoadData
               // 
               resources.ApplyResources(this.buttonLoadData, "buttonLoadData");
               this.buttonLoadData.Name = "buttonLoadData";
               this.buttonLoadData.UseVisualStyleBackColor = true;
               this.buttonLoadData.Click += new System.EventHandler(this.buttonLoadData_Click);
               // 
               // buttonUpdateMain
               // 
               resources.ApplyResources(this.buttonUpdateMain, "buttonUpdateMain");
               this.buttonUpdateMain.Name = "buttonUpdateMain";
               this.buttonUpdateMain.UseVisualStyleBackColor = true;
               this.buttonUpdateMain.Click += new System.EventHandler(this.buttonUpdateMain_Click);
               // 
               // buttonUpdate1
               // 
               resources.ApplyResources(this.buttonUpdate1, "buttonUpdate1");
               this.buttonUpdate1.Name = "buttonUpdate1";
               this.buttonUpdate1.UseVisualStyleBackColor = true;
               // 
               // buttonUpdate2
               // 
               resources.ApplyResources(this.buttonUpdate2, "buttonUpdate2");
               this.buttonUpdate2.Name = "buttonUpdate2";
               this.buttonUpdate2.UseVisualStyleBackColor = true;
               // 
               // button1
               // 
               resources.ApplyResources(this.button1, "button1");
               this.button1.Name = "button1";
               this.button1.UseVisualStyleBackColor = true;
               // 
               // MainForm
               // 
               resources.ApplyResources(this, "$this");
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.Controls.Add(this.tableLayoutPanel1);
               this.Name = "MainForm";
               ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
               this.tableLayoutPanel1.ResumeLayout(false);
               this.tableLayoutPanel2.ResumeLayout(false);
               this.ResumeLayout(false);

          }

          #endregion

          private System.Windows.Forms.DataGridView dataGridView1;
          private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
          private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
          private System.Windows.Forms.Button buttonLoadData;
          private System.Windows.Forms.Button buttonUpdateMain;
          private System.Windows.Forms.Button buttonUpdate1;
          private System.Windows.Forms.Button buttonUpdate2;
          private System.Windows.Forms.Button button1;
     }
}

