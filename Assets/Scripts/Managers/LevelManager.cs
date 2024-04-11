using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Button lvl1Button;
        [SerializeField] private Button lvl2Button;
        [SerializeField] private Button lvl3Button;

        [SerializeField] private Text inGameLvlText;
        [SerializeField] private Text inGameNextLvlText;

        private ColorBlock cb;

        private void Start()
        {
            cb = lvl1Button.colors;
            cb.disabledColor = Color.cyan;
        }

        void Update()
        {
            if (GameManager.Instance.level == 0)
            {
                lvl1Button.interactable = true;
                lvl2Button.interactable = false;
                lvl3Button.interactable = false;
                inGameLvlText.text = "0";
                inGameNextLvlText.text = "1";
            }
            else if (GameManager.Instance.level == 1)
            {
                lvl1Button.colors = cb;
                lvl1Button.interactable = false;
                lvl2Button.interactable = true;
                lvl3Button.interactable = false;
                inGameLvlText.text = "1";
                inGameNextLvlText.text = "2";
            }
            else if (GameManager.Instance.level == 2)
            {
                lvl1Button.colors = cb;
                lvl2Button.colors = cb;
                lvl1Button.interactable = false;
                lvl2Button.interactable = false;
                lvl3Button.interactable = true;
                inGameLvlText.text = "2";
                inGameNextLvlText.text = "3";
            }
            else if (GameManager.Instance.level == 3)
            {
                lvl1Button.colors = cb;
                lvl2Button.colors = cb;
                lvl3Button.colors = cb;
                inGameLvlText.text = "3";
                inGameNextLvlText.text = "4";
            }
        }
    }
}