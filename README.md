# AES_PlayerPrefs
PlayerPrefs를 AES암호화 하여 저장하는 방법입니다.


# 특징
* PlayerPrefs를 사용합니다.
* 저장되는 값은 AES 암호화를 사용해서 암호화합니다.

# 사용 방법

1. 아래 그림과 같이 CrossPlatformSecureStore 클래스를 인스턴스화 합니다.
![image](https://github.com/user-attachments/assets/c90d120e-8ef2-45ed-8069-2c174ac28bc7)
* 여러가지 플랫폼 대응을 위해, ISecureStroe를 상속받은 클래스입니다.
![image](https://github.com/user-attachments/assets/3f730137-e353-4ab1-9b3e-89d3c8642ff9)

2. 저장과 불러오기 방법입니다. (기본적으로 string을 사용합니다.)
![image](https://github.com/user-attachments/assets/e511bd85-cb8a-4df8-899e-01a2c068dd91)

3. 저장되는 값은 아래 그림처럼 암호화되어 저장됩니다.
![image](https://github.com/user-attachments/assets/335dcd4d-2803-40bf-8ebc-ede27faffab6)


