using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    const int StageTipSize = 30;
    int currentTipIndex;

    //�^�[�Q�b�g�L�����̎w��
    public Transform character;
    //�X�e�[�W���z��
    public GameObject[] stageTips;

    //���������Ɏg���ϐ�
    public int startTipIndex;

    //�X�e�[�W�̐�ǂݍ��݌�
    public int preInstantiate;

    //���������̂̕ێ����X�g
    public List<GameObject> generatedStageList = new List<GameObject>();
        
    // Start is called before the first frame update
    void Start()
    {
        //����������
        currentTipIndex = startTipIndex - 1;
        UpdateStage(preInstantiate);

    }

    // Update is called once per frame
    void Update()
    {
        //�L�����N�^�[�̈ʒu���猻�݂̃X�e�[�W�`�b�v�̃C���f�b�N�X���v�Z���܂�
        int charaPositionIndex = (int)(character.position.z / StageTipSize);

        //���̃X�e�[�W�`�b�v�ɓ�������X�e�[�W�̍X�V�������s���܂��B
        if (charaPositionIndex + preInstantiate > currentTipIndex)
        {
            UpdateStage(charaPositionIndex + preInstantiate);
        }
    }

    //�w��̃C���f�b�N�X�܂ł̃X�e�[�W�`�b�v�𐶐����āA�Ǘ����ɂ���
    void UpdateStage(int toTipIndex)
    {
        if (toTipIndex <= currentTipIndex) return;
        //�w��̃X�e�[�W�`�b�v�܂Ő��������
        for (int i = currentTipIndex + 1; i <= toTipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i);
            //���������X�e�[�W�`�b�v���Ǘ����X�g�ɒǉ����āA
            generatedStageList.Add(stageObject);
        }
        //�X�e�[�W�ێ�����ɂȂ�܂ŌÂ��X�e�[�W���폜���܂��B
        while (generatedStageList.Count > preInstantiate + 2) DestroyOldestStage();

        currentTipIndex = toTipIndex;
    }

    //�w��̃C���f�b�N�X�ʒu��stage�I�u�W�F�N�g�������_���ɐ���
    GameObject GenerateStage(int tipIndex)
    {
        int nextStageTip = Random.Range(0, stageTips.Length);

        GameObject stageObject = (GameObject)Instantiate(
            stageTips[nextStageTip],
            new Vector3(0, 0, tipIndex * StageTipSize),
            Quaternion.identity);
        return stageObject;
    }

    //��ԌÂ��X�e�[�W���폜���܂�
    void DestroyOldestStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }


}
