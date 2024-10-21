using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace PR_23106Sborschikov4;

public partial class MainWindow : Window{
    public MainWindow(){
        InitializeComponent();
    }
    public async void CalculateButton_Click(object sender, RoutedEventArgs e){
        try{
            string inputText = inputTextBox.Text;

            if (string.IsNullOrWhiteSpace(inputText)){
                await ShowMessage("Введите предложение.");
                return;
            }

            string[] words = inputText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++){
                if (words[i].Length > 0){
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1, words[i].Length - 2) + char.ToUpper(words[i][words[i].Length - 1]);
                }
            }
            string result = string.Join("это_пробел", words);

            await ShowMessage(result);
        } catch (Exception ex) {
            await ShowMessage("Произошла ошибка: " + ex.Message);
        }
    }

    private async Task ShowMessage(string message){
        var messageBox = new Window(){
            Title = "Сообщение",
            Content = message,
            Width = 300,
            Height = 200
        };

        await messageBox.ShowDialog(this);
    }
}