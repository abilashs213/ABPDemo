mkcert `
"demo-st-authserver" `
"demo-st-angular" `
"demo-st-public-web" `
"demo-st-gateway-web" "demo-st-gateway-web-public" `
"demo-st-identity" "demo-st-administration" "demo-st-saas" "demo-st-product" 
kubectl create namespace demo
kubectl create secret tls -n demo demo-tls --cert=./demo-st-authserver+8.pem  --key=./demo-st-authserver+8-key.pem