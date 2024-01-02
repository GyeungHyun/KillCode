using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
   public Animator anim;
   public float speed;
   Vector3 destPos;
   Vector3 dir;
   Quaternion lookTarget;

   private void Update()
   {
      RaycastHit hit;
      // 메인 카메라를 통해 마우스 클릭한 곳의 ray 정보를 가져옴
      var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         
      // ray와 닿은 물체가 있는지 검사
      if (Physics.Raycast(ray, out hit, 100f))
      {
         print(hit.transform.name);
            
         // hit.point 는 마우스 클릭한 곳의 월드 좌표.
         // 이 예제에서 캐릭터의 y 값(높이) 은 변하지 않기 때문에 
         // 아래와 같이 목표위치를 재설정합니다.
         destPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            
         // 현재 위치와 목표 위치의 방향 벡터
         dir = destPos - transform.position;
            
         // 바라 보아야 할 곳의 Quaternion
         lookTarget = Quaternion.LookRotation(dir);
         transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, 0.25f);
      }
      realMove();
   }


   void realMove()
   {
      float moveX = Input.GetAxisRaw("Horizontal");
      float moveY = Input.GetAxisRaw("Vertical");

      Vector3 moveVector = new Vector3(moveX, 0f, moveY);
      transform.Translate(moveVector.normalized * Time.deltaTime * speed);
      bool isMove = moveVector.magnitude > 0;
      anim.SetBool("walk",isMove);
   }
}
