using UnityEngine;
using UnityEngine.SceneManagement;

// Этот скрипт управляет меню паузы: ставит игру на стоп и снова запускает
public class MainMenu : MonoBehaviour
{
    public static bool IsPaused;
    // Сюда в инспекторе перетаскиваем объект меню (тёмный фон с кнопками),
    // чтобы скрипт знал, что именно показывать и прятать
    public GameObject menuRoot;

    public GameObject cam1;
    public GameObject cam2;

    // Когда мы прячем курсор в игре (как в шутерах), нужно запомнить,
    // каким он был. Иначе после паузы не сможем вернуть всё как было
    private CursorLockMode cursorLockBeforePause;
    private bool cursorVisibleBeforePause;
    public GameObject menu_canv;
    public GameObject player;

    private void Awake()
    {
        Time.timeScale = 0f;
        ShowMenu();
        IsPaused = false;
        menu_canv.SetActive(false);
        player.SetActive(false);

        cam1.GetComponent<person_Camera>().enabled = false; ;
        cam2.GetComponent<Second_camera_script>().enabled = false;
        
    }

    private void Update()
    {
        // GetKeyDown срабатывает только в момент нажатия Esc (один раз)
    }

    public void Pause()
    {
        IsPaused = true;

        // timeScale — это скорость времени в игре. 0 значит "время стоит":
        Time.timeScale = 0f;
        // персонаж замирает, анимации не идут. Так и получается паузf
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

        // Возвращаем 1 — обычную скорость времени, чтобы снять паузуwwwwww
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


    public void Settings()
    {

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
            player.SetActive(false);
            menu_canv.SetActive(false);
            cam1.GetComponent<person_Camera>().enabled = false;
            cam2.GetComponent<Second_camera_script>().enabled = false;
        }
    }

    private void HideMenu()
    {
        if (menuRoot != null)
        {
            menuRoot.SetActive(false);
            player.SetActive(true);
            menu_canv.SetActive(true);
            cam1.GetComponent<person_Camera>().enabled = true;
            cam2.GetComponent<Second_camera_script>().enabled = true;
        }
    }
}
