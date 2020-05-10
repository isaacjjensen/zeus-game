/*
//Additional Inputs Needed:
//Edit > Project Settings > Input Manager > Increase Size value by 3
    //DevMode -> positiveButton f1
    //DevKill -> positiveButton f2
    //Fall    -> positiveButton r  (? potentially change any of these lol)

//CharacterMotor.cs additions
//------------------------------------------------
    //Within CharacterMotor class

        public bool DevToggle = false;


    //------------------------------------------------
    //  Updated Update() Function

        void Update()
        {
            if(!useFixedUpdate)
                UpdateFunction();

            if(Input.GetButtonDown("DevMode")) {
                DevToggle = !DevToggle;
                movement.velocity = Vector3.zero;
            }

            if(DevToggle) {
                movement.gravity = 0.0f;

                if(Input.GetButtonDown("Jump")) {
                    Vector3 flyVector = new Vector3(0.0f, 4.0f, 0.0f);
                    movement.velocity += flyVector;
                }

                if(Input.GetButtonDown("Fall")) {
                    Vector3 fallVector = new Vector3(0.0f, -4.5f, 0.0f);
                    movement.velocity += fallVector;
                }

                if(Input.GetButtonUp("Fall") || Input.GetButtonUp("Jump")) {
                    movement.velocity.y = 0.0f;
                }
            }
            else {
                movement.gravity = 9.81f;
            }
        }

//================================================



//Manager.cs additions
//------------------------------------------------
    //Within Manager Class

        public bool DevToggle = false;


    //------------------------------------------------
    //Within Update() Function

        if(Input.GetButtonDown("DevMode"))
            DevToggle = !DevToggle;
        
        if(DevToggle && Input.GetButtonDown("DevKill")) {
            DevToggle = !DevToggle;
            Kill();
            DevToggle = !DevToggle;
        }
    

    //------------------------------------------------
    //Updated Kill() Function   -   Small Change

        public void Kill()
        {
            if(!DevToggle) {
                GetComponent<CharacterMotor>().movement.velocity = Vector3.zero;
                FindObjectOfType<menuDeath>().killPlayer();
            }
        }
*/