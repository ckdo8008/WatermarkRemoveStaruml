# 레지스트리 등록

win + R

```
regedit 
```

## 키 추가

```
컴퓨터\HKEY_CLASSES_ROOT\*\shell\removeWatermark
```

## 키 추가

```
컴퓨터\HKEY_CLASSES_ROOT\*\shell\removeWatermark\command
```

## 기본값 수정

```
"{path}\WatermarkRemoveStaruml.exe" "%1"
```