using System.Collections.Generic;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Adaptive;
using Microsoft.Bot.Builder.Dialogs.Adaptive.Actions;
using Microsoft.Bot.Builder.Dialogs.Adaptive.Conditions;
using Microsoft.Bot.Builder.Dialogs.Adaptive.Recognizers;

namespace AdaptiveCard1.BotDialog
{
    public class RootDialog : ComponentDialog
    {
        public RootDialog() : base(nameof(RootDialog))
        {
           // var templates = Templates.ParseFile(Path.Combine(".", "Dialogs", "RootDialog.lg"));

            var rootDialog = new AdaptiveDialog
            {
                Recognizer = CreateRecognizer(),
                Triggers = new List<OnCondition>
                {
                    new OnIntent()
                    {
                        Intent = "hi",
                        Actions = new List<Dialog>() {new SendActivity("how can i help you")}
                    },

                    new OnIntent()
                    {
                        Intent="hello",
                        Actions = new List<Dialog>() {new SendActivity("How can i help you")}
                    },
                    new OnIntent()
                    {
                        Intent="issue",
                        Actions=new List<Dialog>(){new SendActivity("what is the issue you are facing ")}
                        
                    },
                    new OnIntent()
                    {
                        Intent="incident",
                        Actions=new List<Dialog>(){new SendActivity("Can i create incident for you ")}

                    },
                    new OnUnknownIntent()
                    {
                        Actions=new List<Dialog>(){new SendActivity("sorry,i don't undersatnd")}
                    }


                }
            };

            AddDialog(rootDialog);

            InitialDialogId = nameof(AdaptiveDialog);
        }


        private Recognizer CreateRecognizer()
        {
            var reg = new RegexRecognizer
            {
                Intents = new List<IntentPattern>
                {
                    new IntentPattern("hi", "(?i)hi"),
                    new IntentPattern("hello", "(?i)hello"),
                    new IntentPattern("issue","(?i)issue"),
                    new IntentPattern("incident","(?i)incident")
                }
            };
            return reg;
        }
    }
}