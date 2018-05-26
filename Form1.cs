using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Utils;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;


namespace VkForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            adminIDTextBox.SelectionAlignment = HorizontalAlignment.Center;
            ThresholdValueTextBox.SelectionAlignment = HorizontalAlignment.Center;
            DownloadCommentsButton.Enabled = false;
            vkApi = new VkApi();

            allGroups.Add(new vkGroup("ЁП", -12382740));
            allGroups.Add(new vkGroup("Мой и твой Воронеж", -10889156));
            allGroups.Add(new vkGroup("Воронеж", -52944751));
            allGroups.Add(new vkGroup("Воронеж VRN", -98018205));
            allGroups.Add(new vkGroup("Подслушано у Водителей Воронежа", -79050190));
            allGroups.Add(new vkGroup("ЗШ", -29544671));
            allGroups.Add(new vkGroup("4ch", -45745333));
            allGroups.Add(new vkGroup("Орленок", -36775802));
            allGroups.Add(new vkGroup("Воронеж", -52944751));
            allGroups.Add(new vkGroup("Лепра", -30022666));
            allGroups.Add(new vkGroup("Нетипичный Воронеж", -134884423));
            allGroups.Add(new vkGroup("Vine Video", -57876954));
            allGroups.Add(new vkGroup("Подслушано Воронеж", -56957305));
            allGroups.Add(new vkGroup("Типичный программист", -30666517));
            allGroups.Add(new vkGroup("MDK", -57846937));
            allGroups.Add(new vkGroup("МХК", -41437811));
            allGroups.Add(new vkGroup("Типичный Воронеж", -33041211));
            allGroups.Add(new vkGroup("Pro Воронеж", -108370037));
            allGroups.Add(new vkGroup("Настоящий Воронеж", -35824409));

            foreach (var it in allGroups)
            {
                GroupList.Items.Add(it.groupName);
            }
            GroupList.SelectedItem = GroupList.Items[0];
            Authorize();

        }



        static VkApi vkApi = null;
        static int AppID /* = Your App ID*/;
        static string email /* = Your Login*/;
        static string password /* = Yourpassword*/;
        static uint maxSingleOffser = 1000;
        static int maxPostForAnalysis = 100;
        static ulong maxPostFromVkDatabase = 100;

        static List<vkGroup> allGroups = new List<vkGroup>();
        static List<long> listOfPostsForAnalysis = new List<long>();
        SortedSet<long> UnicUsersIDFromAllselectedPosts = new SortedSet<long>();
        static List<SortedSet<long>> UsersIDFromAllselectedPosts = new List<SortedSet<long>>();

        static void PrintFoFile(FileStream fstream, String text)
        {

            byte[] array = System.Text.Encoding.Default.GetBytes(text);
            byte[] newline = System.Text.Encoding.Default.GetBytes("\r\n");
            fstream.Write(array, 0, array.Length);
            fstream.Write(newline, 0, newline.Length);
        }

        static void GetFriends(long userID)
        {
            var users = vkApi.Friends.Get(userID, ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Uid);

            foreach (var friend in users)
            {
                Console.WriteLine(friend.FirstName + " " + friend.LastName + " | " + friend.Id);
            }
        }

        static String GetName(long? userID)
        {
            long id = long.Parse(userID.ToString());
            return vkApi.Users.Get(id).FirstName + " " + vkApi.Users.Get(id).LastName;

        }

        static String GetName(long userID)
        {
            return vkApi.Users.Get(userID).FirstName + " " + vkApi.Users.Get(userID).LastName;

        }

        static String GetName1(String userID)
        {
            long id = long.Parse(userID);
            return vkApi.Users.Get(id).FirstName + " " + vkApi.Users.Get(id).LastName;
        }

        vkGroup chosenGroup()
        {
            String str = GroupList.SelectedItem.ToString();
            foreach (var it in allGroups)
            {
                if (it.groupName == str)
                {
                    return new vkGroup(it.groupName, it.groupID);
                }
            }
            return null;
        }

        private void Authorize()
        {
            try
            {
                vkApi.Authorize(AppID, email, password, Settings.All);
                UserName.Text = "Username: " + GetName(vkApi.UserId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void authorizeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Authorize();
        }

        private void ShowPostsButton_Click(object sender, EventArgs e)
        {

            Posts.Name = "Posts";
            Posts.Rows.Clear();
            this.Controls.Add(Posts);
            Posts.ColumnCount = 2;

            Posts.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            Posts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Posts.ColumnHeadersDefaultCellStyle.Font = new Font(Posts.Font, FontStyle.Bold);
            Posts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            Posts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            Posts.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            Posts.GridColor = Color.Black;
            Posts.RowHeadersVisible = false;
            Posts.Columns[0].Name = "Post ID";
            Posts.Columns[1].Name = "Text";

            try
            {
                uint AllLikesCount = 0;
                WallGetParams wallParam = new WallGetParams();
                wallParam.OwnerId = chosenGroup().groupID;
                wallParam.Count = ulong.Parse(numberOfPosts.Text);


                WallGetObject wallObjects = vkApi.Wall.Get(wallParam);

                foreach (var post_it in wallObjects.WallPosts)
                {
                    AllLikesCount = (uint)post_it.Likes.Count;
                    long PostID = long.Parse(post_it.Id.ToString());
                    string[] row = { PostID.ToString(), post_it.Text };
                    Posts.Rows.Add(row);
                }


                Posts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Posts.Columns[0].Width = 60;
                Posts.Columns[1].Width = 360;


            }
            catch (Exception except) { MessageBox.Show(except.Message, "Error!\n"); }
        }


        int GetNumberOfComments(long PostID)
        {
            WallGetParams wallGetParams = new WallGetParams();
            wallGetParams.OwnerId = chosenGroup().groupID;
            wallGetParams.Count = ulong.Parse(numberOfPosts.Text);
            WallGetObject wallObjects = vkApi.Wall.Get(wallGetParams);
            foreach (var post_it in wallObjects.WallPosts)
            {
                if (post_it.Id == PostID)
                {
                    return post_it.Comments.Count;
                }
            }
            return -1;
        }

        private void DownloadCommentsButton_Click(object sender, EventArgs e)
        {
            long PostID = long.Parse(Posts.CurrentRow.Cells[0].Value.ToString());
            WallGetCommentsParams wallparams = new WallGetCommentsParams();
            wallparams.Count = 100;
            wallparams.OwnerId = chosenGroup().groupID;
            wallparams.PostId = PostID;
            wallparams.Sort = 0; // Desc
            wallparams.NeedLikes = true;

            using (FileStream fstream = new FileStream(PostID.ToString() + ".txt", FileMode.Create))
            {


                int AllLikesCount = GetNumberOfComments(PostID);
                int i = 0;
                while (AllLikesCount > 0)
                {
                    wallparams.Offset = i * 100;
                    VkCollection<Comment> comments = vkApi.Wall.GetComments(wallparams);
                    foreach (var it in comments)
                    {

                        PrintFoFile(fstream, it.FromId + " Likes:" + it.Likes.Count + " Text:" + it.Text + " ");
                    }
                    i++;
                    AllLikesCount -= 100;
                }
                MessageBox.Show("Comments save to file");

            }




        }


        private void ClearButton_Click(object sender, EventArgs e)
        {
            selectedPostsLabel.Text = "";
            listOfPostsForAnalysis.Clear();
            GroupList.Enabled = true;
            progressBar1.Value = 0;
            SaveToFileprogressBar1.Value = 0;
            UnicUsersIDFromAllselectedPosts.Clear();
            UsersIDFromAllselectedPosts.Clear();
            ThresholdValueTextBox.Text = "0";
        }

        //оба пользователя лайкнули запись?
        bool ifUsersLikePost(long user_1, long user_2, List<long> listLike)
        {

            bool b1 = listLike.Exists(x => x == user_1);
            bool b2 = listLike.Exists(x => x == user_2);
            if (b1 && b2)
            {
                return true;
            }
            return false;
        }

        static bool ifUsersLikePost(long user_1, long user_2, SortedSet<long> listLike)
        {

            bool b1 = listLike.Contains(user_1);
            bool b2 = listLike.Contains(user_2);
            if (b1 && b2)
            {
                return true;
            }
            return false;
        }

        void SaveResultsToFile()
        {
            String adminID;
            int ThresholdValue = 0;
            try
            {
                adminID = adminIDTextBox.Text;
                ThresholdValue = Int32.Parse(ThresholdValueTextBox.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Enter the data correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveToFileprogressBar1.Value = 0;
            SaveToFileprogressBar1.Maximum = UnicUsersIDFromAllselectedPosts.Count;

            HashSet<long> listUnicID = new HashSet<long>();

            foreach (var it in UnicUsersIDFromAllselectedPosts)
            {
                listUnicID.Add(it);
            }

            Console.WriteLine("Number of users: " + listUnicID.Count);



            int bufsize = 1024 * 1024;
            using (FileStream fstream = new FileStream(@"vk output.txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite, bufsize))
            {

                int i = 0;
                foreach (var external_it in listUnicID)    // декартово 
                {
                    int j = 0;
                    int commonWithAdmin = 0;

                    foreach (var inner_it in listUnicID)   // произведение всех пользователей
                    {
                        int count = 0;
                        foreach (var post_it in UsersIDFromAllselectedPosts)
                        {
                            if (ifUsersLikePost(external_it, inner_it, post_it) && external_it != inner_it) { count++; }
                        }
                        commonWithAdmin += count;
                        if (count >= ThresholdValue)
                        {
                            PrintFoFile(fstream, i + " " + j + " " + count);
                        }
                        j++;
                    }


                    SaveToFileprogressBar1.Value++;
                    i++;
                }
            }
        }

        void SaveLikesFromPostToFile(long GroupID, long PostID, FileStream fstream)
        {
            int AllLikesCount = 0;

            WallGetParams wallParam = new WallGetParams();
            wallParam.OwnerId = GroupID;
            wallParam.Count = maxPostFromVkDatabase;


            WallGetObject wallObjects = vkApi.Wall.Get(wallParam);



            foreach (var post_it in wallObjects.WallPosts)
            {
                AllLikesCount = post_it.Likes.Count;
                if (post_it.Id != PostID)
                {
                    continue;
                }

                LikesGetListParams likeParams = new LikesGetListParams();
                likeParams.Type = LikeObjectType.Post;
                likeParams.ItemId = PostID;
                likeParams.Extended = true;
                likeParams.OwnerId = GroupID;
                likeParams.Count = 1000;

                uint i = 0;
                while (AllLikesCount > 0) // выбираем по 1000 id(максимум)
                {
                    VkCollection<long> likes = vkApi.Likes.GetList(likeParams);
                    foreach (var itLike in likes)
                    {
                        PrintFoFile(fstream, itLike.ToString()); //запись каждого id  в файл
                    }
                    AllLikesCount -= (int)maxSingleOffser;
                    i++;
                    likeParams.Offset = i * maxSingleOffser; // увеличиваем каждый раз смещение 
                    Thread.Sleep(300);  // чтобы избежать "Too many requests per second
                }


                Console.WriteLine(post_it.Likes.Count);
                Console.WriteLine(AllLikesCount);
                ;

            }


        }

        SortedSet<long> SaveUsersIDFromPostToList(long GroupID, long PostID)
        {
            SortedSet<long> UsersID = new SortedSet<long>();
            int AllLikesCount = 0;

            WallGetParams wallParam = new WallGetParams();
            wallParam.OwnerId = GroupID;
            wallParam.Count = maxPostFromVkDatabase;


            WallGetObject wallObjects = vkApi.Wall.Get(wallParam);



            foreach (var post_it in wallObjects.WallPosts)
            {
                AllLikesCount = post_it.Likes.Count;
                if (post_it.Id != PostID)
                {
                    continue;
                }

                LikesGetListParams likeParams = new LikesGetListParams();
                likeParams.Type = LikeObjectType.Post;
                likeParams.ItemId = PostID;
                likeParams.Extended = true;
                likeParams.OwnerId = GroupID;
                likeParams.Count = 1000;

                uint i = 0;
                while (AllLikesCount > 0) // выбираем по 1000 id(максимум)
                {
                    VkCollection<long> likes = vkApi.Likes.GetList(likeParams);

                    foreach (var itLike in likes)
                    {
                        UsersID.Add(itLike);
                    }
                    AllLikesCount -= (int)maxSingleOffser;
                    i++;
                    likeParams.Offset = i * maxSingleOffser; // увеличиваем каждый раз смещение 
                    Thread.Sleep(300);  // чтобы избежать "Too many requests per second
                }


            }
            return UsersID;

        }


        private void SaveUsersIDtoFileButton_Click(object sender, EventArgs e)
        {
            long GroupID = chosenGroup().groupID;
            progressBar1.Value = 0;
            progressBar1.Maximum = listOfPostsForAnalysis.Count();

            foreach (var post_it in listOfPostsForAnalysis)
            {
                SortedSet<long> UsersIDlist = SaveUsersIDFromPostToList(GroupID, post_it);
                UsersIDFromAllselectedPosts.Add(UsersIDlist);

                foreach (var userID in UsersIDlist) //добавление id пользователей в общий пул
                {
                    UnicUsersIDFromAllselectedPosts.Add(userID);

                }

                progressBar1.Value++;
            }
            progressBar1.Value = progressBar1.Maximum;

            SaveResultsToFile();

        }

        private void Posts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GroupList.Enabled = false;
            if (listOfPostsForAnalysis.Count == maxPostForAnalysis)
            {
                MessageBox.Show("You select max post for analysis(" + maxPostForAnalysis + ")");
                return;
            }
            long PostID = long.Parse(Posts.CurrentRow.Cells[0].Value.ToString());

            if (listOfPostsForAnalysis.IndexOf(PostID) != -1) //элемент уже существует 
            {
                return;
            }

            listOfPostsForAnalysis.Add(PostID);

            selectedPostsLabel.Text = "Вы выбрали: \n";

            for (int i = 0; i < listOfPostsForAnalysis.Count; i++)
            {
                selectedPostsLabel.Text += listOfPostsForAnalysis.ElementAt(i) + ", ";

                if (i % 3 == 0)
                {
                    selectedPostsLabel.Text += "\n";
                }
            }
        }








    }


}
