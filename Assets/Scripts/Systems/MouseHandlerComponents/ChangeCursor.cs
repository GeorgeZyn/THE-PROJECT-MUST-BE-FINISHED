using UnityEngine;

namespace Systems.Mouse
{
   public class ChangeCursor : MonoBehaviour
   {
      [SerializeField] private Texture2D cursor;
      [SerializeField] private Vector2 hotspot;

      private void OnMouseEnter()
      {
         Cursor.SetCursor(cursor, hotspot, CursorMode.Auto);
      }

      private void OnMouseExit()
      {
         Cursor.SetCursor(null, new Vector2(32, 32), CursorMode.Auto);
      }
   }
}