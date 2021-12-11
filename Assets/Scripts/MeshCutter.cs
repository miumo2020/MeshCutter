using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCutter : MonoBehaviour
{
    public GameObject TargetObject;

    public GameObject In;  // TODO: ����m�F�p
    public GameObject Out;  // TODO: ����m�F�p

    // �ؒf�p�I�u�W�F�N�g�̐ؒf�ʃ��b�V�����
    private MeshFilter cutterMeshFilter;
    private Mesh cutterMesh;

    // �ؒf�ΏۃI�u�W�F�N�g�̃��b�V�����
    private MeshFilter targetMeshFilter;
    private Mesh targetMesh;

    private Plane cutPlane;  // TODO: ����m�F�p

    void Start()
    {
        // �ؒf�pmesh�̎擾
        cutterMeshFilter = GetComponent<MeshFilter>();
        cutterMesh = cutterMeshFilter.mesh;

        // �ؒf�Ώ�object��mesh�擾
        targetMeshFilter = TargetObject.GetComponent<MeshFilter>();
        targetMesh = targetMeshFilter.mesh;


        // TODO: ����m�F�p�ɐؒf���ʂ��쐬
        cutPlane = new Plane(new Vector3(0, 1, 0), Vector3.zero);


        Test();
    }

    //void Update()  TODO: ����m�F�̂��߃R�����g�A�E�g
    void Test()
    {
        DVector3 p1, p2, p3;
        bool p1Bool, p2Bool, p3Bool;

        // �J�b�g�������I�u�W�F�N�g�̃��b�V�����g���C�A���O�����Ƃɏ���
        for (int i = 0; i < targetMesh.triangles.Length; i += 3)
        {
            // ���b�V����3�̒��_���擾
            p1 = new DVector3(transform.TransformPoint(targetMesh.vertices[targetMesh.triangles[i]]));
            p2 = new DVector3(transform.TransformPoint(targetMesh.vertices[targetMesh.triangles[i + 1]]));
            p3 = new DVector3(transform.TransformPoint(targetMesh.vertices[targetMesh.triangles[i + 2]]));

            // ���_���ؒf�ʂ̂ǂ��瑤�ɂ��邩(true: �����Afalse: �O��)
            p1Bool = DVector3.Dot(new DVector3(cutPlane.normal), p1) + (double)cutPlane.distance < 0 ? true : false;
            p2Bool = DVector3.Dot(new DVector3(cutPlane.normal), p2) + (double)cutPlane.distance < 0 ? true : false;
            p3Bool = DVector3.Dot(new DVector3(cutPlane.normal), p3) + (double)cutPlane.distance < 0 ? true : false;

            // 3�̒��_���S�ē����ɂ���ꍇ�͂��̂܂܃��b�V���o�^
            if (p1Bool && p2Bool && p3Bool)
            {
                // TODO
                Instantiate(In, new Vector3((float)p1.x, (float)p1.y, (float)p1.z), Quaternion.identity);  // ����m�F�p
            }
            // 3�̒��_���S�ĊO���ɂ���ꍇ�͕\������K�v���Ȃ����߃X�L�b�v
            else if (!p1Bool && !p2Bool && !p3Bool)
            {
                // TODO
                Instantiate(Out, new Vector3((float)p1.x, (float)p1.y, (float)p1.z), Quaternion.identity);  // ����m�F�p
            }
            else
            {
                // TODO
            }
        }
    }
}
