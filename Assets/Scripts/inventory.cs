using UnityEngine;
using UnityEngine.SceneManagement;


public class inventory : MonoBehaviour
{
    public static bool IsPaused;

    // Сюда в инспекторе перетаскиваем объект меню (тёмный фон с кнопками),
    // чтобы скрипт знал, что именно показывать и прятать
    public GameObject menuRoot;

    // Когда мы прячем курсор в игре (как в шутерах), нужно запомнить,
    // каким он был. Иначе после паузы не сможем вернуть всё как было
    private CursorLockMode cursorLockBeforePause;
    private bool cursorVisibleBeforePause;

    private void Awake()
    {
        HideMenu();
        IsPaused = false;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        // GetKeyDown срабатывает только в момент нажатия Esc (один раз)
        if (Input.GetKeyDown(KeyCode.I))
        {

            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        IsPaused = true;

        // timeScale — это скорость времени в игре. 0 значит "время стоит":
        // персонаж замирает, анимации не идут. Так и получается паузf
        Time.timeScale = 0f;
        ShowMenu();

        // Сначала запоминаем, каким был курсор, и только потом меняем его,
        // чтобы потом было что возвращать
        cursorLockBeforePause = Cursor.lockState;
        cursorVisibleBeforePause = Cursor.visible;

        // В меню нужно мышкой нажимать кнопки, поэтому курсор
        // освобождаем (None) и делаем видимым
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        IsPaused = false;

        // Возвращаем 1 — обычную скорость времени, чтобы снять паузу
        Time.timeScale = 1f;
        HideMenu();

        // Ставим курсор обратно таким, каким он был до паузы
        Cursor.lockState = cursorLockBeforePause;
        Cursor.visible = cursorVisibleBeforePause;
    }

    public void Restart()
    {
        // Сначала снимаем паузу: если этого не сделать, новая сцена
        // загрузится с остановленным временем (timeScale остался бы 0)
        Resume();

        // buildIndex — это номер текущей сцены. Загружаем её же заново —
        // получается перезапуск уровня с самого начала
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void Quit()
    {
        // В редакторе Unity "выйти из игры" нельзя, поэтому просто
        // выключаем режим Play. А в собранной игре — закрываем приложение
        // #if нужен, чтобы каждый вариант работал в своём случае
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // Показ и скрытие меню вынесены в отдельные методы, чтобы не повторять
    // одну и ту же проверку в разных местах
    private void ShowMenu()
    {
        if (menuRoot != null)
        {
            menuRoot.SetActive(true);
        }
    }

    private void HideMenu()
    {
        if (menuRoot != null)
        {
            menuRoot.SetActive(false);
        }
    }
}

