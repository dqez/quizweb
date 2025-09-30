    // Temporarily using internal script in index.cshtml


//document.addEventListener('DOMContentLoaded', function () {
//    const editables = document.querySelectorAll('.editable');

//    editables.forEach(span => {
//        span.addEventListener('click', function () {
//            if (this.querySelector('input')) return; // Đang edit rồi thì thôi

//            const fieldName = this.dataset.field;
//            const currentValue = this.textContent;

//            // Tạo input
//            const input = document.createElement('input');
//            input.type = 'text';
//            input.value = currentValue;
//            input.className = 'editing-input';

//            // Xóa text, thêm input
//            this.textContent = '';
//            this.appendChild(input);
//            input.focus();

//            // Khi blur hoặc Enter → save
//            const saveEdit = async () => {
//                const newValue = input.value;

//                if (newValue === currentValue) {
//                    // Không thay đổi → restore
//                    span.textContent = currentValue;
//                    return;
//                }

//                try {
//                    // Gọi AJAX
//                    const response = await fetch('@Url.Action("UpdateField", "Profile")', {
//                        method: 'POST',
//                        headers: {
//                            'Content-Type': 'application/json',
//                            'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
//                        },
//                        body: JSON.stringify({
//                            fieldName: fieldName,
//                            value: newValue
//                        })
//                    });

//                    const result = await response.json();

//                    if (result.success) {
//                        span.textContent = newValue;
//                    } else {
//                        alert('Error: ' + result.message);
//                        span.textContent = currentValue;
//                    }
//                } catch (error) {
//                    alert('Network error');
//                    span.textContent = currentValue;
//                }
//            };

//            input.addEventListener('blur', saveEdit);
//            input.addEventListener('keypress', function (e) {
//                if (e.key === 'Enter') {
//                    this.blur();
//                }
//            });
//        });
//    });
//});

//function SelectChange(select) {

//    const fieldName = select.dataset.field;
//    const value = select.value;
//    console.log(`selected: ${value}`);

//    const saveChange = async () => {    
//        try {
//            const response = await fetch(window.AppConfig.urls.updateField, {
//                method: 'POST',
//                headers: {
//                    'Content-Type': 'application/json',
//                    'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
//                },
//                body: JSON.stringify({
//                    fieldName: fieldName,
//                    value: value
//                })
//            });

//            const result = await response.json();

//            if (result.success) {
//                //re select default with new valu
//            }
//            else {
//                alert('Error ' + result.message);
//            }

//        } catch (e) {
//            alert('tryCatch ajax saveChange');
//        }


//    }

//    saveChange();

//}