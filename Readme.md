# StarUML SVG ���͸�ũ ���� 

SVG Export �� ������ ���͸�ũ�� �ڵ����� �����ϰ� PNG�� ������ �����Ѵ�.

## ������Ʈ�� ���

win + R

```
regedit 
```

### Ű �߰�

```
��ǻ��\HKEY_CLASSES_ROOT\*\shell\removeWatermark
```

### Ű �߰�

```
��ǻ��\HKEY_CLASSES_ROOT\*\shell\removeWatermark\command
```

### command �⺻�� ����

```
"{path}\WatermarkRemoveStaruml.exe" "%1"
```


## png �ڵ� ��ȯ��� �߰�

### ���� �ػ󵵰� �����Ǿ� ����

```
                Save(file, outputPath, 2853);
```

������ �̹����� ��� ������ �� �� ����
