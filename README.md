# kv-tester
A small pod to test your Azure Key Vault access with aad-pod-identity

Use **kv-tester.yml** to deploy this pod in your AKS to test your Azure Key Vault access *(do not forget to replace XXX)*

```
apiVersion: v1
kind: Pod
metadata:
  name: demo-kvt
  labels:
    aadpodidbinding: "XXX"
spec:
  containers:
    - name: kv-tester
      image: ghcr.io/lex2193/kv-tester:master
      imagePullPolicy: Always
      env:
        - name: KEY_VAULT_NAME
          value: XXX
  nodeSelector:
    kubernetes.io/os: linux
```
