# StarUML SVG 워터마크 제거 

SVG Export 된 파일의 워터마크를 자동으로 제거하고 PNG로 파일을 생성한다.

## 레지스트리 등록

win + R

```
regedit 
```

### 키 추가

```
컴퓨터\HKEY_CLASSES_ROOT\*\shell\removeWatermark
```

### 키 추가

```
컴퓨터\HKEY_CLASSES_ROOT\*\shell\removeWatermark\command
```

### command 기본값 수정

```
"{path}\WatermarkRemoveStaruml.exe" "%1"
```


## png 자동 변환기능 추가

### 가로 해상도가 고정되어 있음

```
                Save(file, outputPath, 2853);
```

복잡한 이미지의 경우 문제가 될 수 있음
