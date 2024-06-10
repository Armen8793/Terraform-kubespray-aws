# TERRAFORM-KUBESPRAY-HELM-SOMEC#APP

### clone the kubespray repo 
```
git clone https://github.com/kubernetes-sigs/kubespray.git
```
### enter the dir and copy the credentials
```
cd kubespray/contrib/terraform/aws/
cp credentials.tfvars.example credentials.tfvars
```
### Enter the credentials with 
```
vim credentials.tfvars
```
### and fill the lines with your aws-access-key, secret-key, key-pair and region
### Then need to enter 
```
vim terraform.tfvars
```
### and design the infrastructure

### And at last we can begin terraform commands to initialize, plan and apply our infra
```
terraform init
terraform plan -out my-test-plan -var-file=credentials.tfvars
terraform apply "my-test-plan"
```

### Now we can begin to deploy a Kubernetes cluster using Ansible
```
cd ~/kubespray
cat inventory/hosts
```
### Now load SSH keys, which were created in AWS
```
cat “” > ~/.ssh/mysomekey.pem
eval $(ssh-agent)
ssh-add -D
ssh-add ~/.ssh/mysomekey.pem
```
### now we can deploy our cluster by Ansible
```
ansible-playbook -i ./inventory/hosts ./cluster.yml -e ansible_user=armen -b --become-user=root --flush-cache
```
