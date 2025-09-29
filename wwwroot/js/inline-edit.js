class ProfileInlineEditor {
    constructor() {
        this.originalValues = new Map();
        this.isGlobalEdit = false;
        this.init();
    }

    init() {
        document.querySelectorAll('.edit-btn').forEach(btn => {
            btn.addEventListener('click', (e) => {
                const field = e.target.closest('.edit-field');
                this.enterEditMode(field);
            });
        });

        document.querySelectorAll('.save-btn').forEach(btn => {
            btn.addEventListener('click', (e) => {
                const field = e.target.closest('.edit-field');
                this.saveField(field);
            });
        });


        document.querySelectorAll('.cancel-btn').forEach(btn => {
            btn.addEventListener('click', (e) => {
                const field = e.target.closest('.edit-field');
                this.cancelEdit(field);
            });
        });

        document.getElementById('globalEdit').addEventListener('click', () => {
            this.toggleGlobalEdit();
        });

    }
    enterEditMode(field) {
        const displayValue = field.querySelector('.display-value');
        const editInput = field.querySelector('.edit-input');
        const editControls = field.querySelector('.edit-controls');
        const editBtn = field.querySelector('.edit-btn');

        // Store original value
        const fieldName = field.dataset.field;
        this.originalValues.set(fieldName, editInput.dataset.original);

        // Switch to edit mode
        displayValue.style.display = 'none';
        editInput.style.display = 'block';
        editControls.style.display = 'block';
        editBtn.style.display = 'none';

        // Focus and select text
        editInput.focus();
        if (editInput.type === 'text' || editInput.type === 'email') {
            editInput.select();
        }
    }


    async saveField(field) {
        const fieldName = field.dataset.field;
        const editInput = field.querySelector('.edit-input');
        const displayValue = field.querySelector('.display-value');
        const newValue = editInput.value;


        if (!this.validateField(field, newValue)) {
            return;
        }

        this.showLoading(true);

        try {
            const response = await fetch('/Profile/Edit', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'X-RequestVerificationToken': document.querySelector('[name="__RequestVerificationToken"]')?.value,
                },
                body: JSON.stringify({ field: fieldName, value: newValue })
            });

            const result = await response.json();

            if (result.success) {
                displayValue.textContent = result.formattedValue || this.formatDisplayValue(fieldName, newValue);

                editInput.dataset.original = newValue;
                this.originalValues.delete(fieldName);

                this.exitEditMode(field);

                document.getElementById('lastUpdated').textContent = new Date().toLocaleString();

                this.showToast('success', result.message || 'Field updated successfully!');

                field.classList.add('bg-light');
                setTimeout(() => field.classList.remove('bg-light'), 1000);
            } else {
                this.showToast('error', result.message || 'Failed to update field.');
                this.showFieldError(field, result.message);
            }
        } catch (error) {
            console.error('Update error:', error);
            this.showToast('error', 'Network error. Please try again.');
        } finally {
            this.showLoading(false);
        }
    }
    cancelEdit(field) {
        const fieldName = field.dataset.field;
        const editInput = field.querySelector('.edit-input');
        const originalValue = this.originalValues.get(fieldName);

        if (originalValue != undefined) {
            editInput.value = originalValue;
        }

        this.enterEditMode(field);
        this.originalValues.delete(fieldName);
    }

    toggleGlobalEdit() {
        const globalBtn = document.getElementById('globalEdit');

        if (!this.isGlobalEdit) {
            // Enter global edit mode
            document.querySelectorAll('.edit-field').forEach(field => {
                this.enterEditMode(field);
            });
            globalBtn.innerHTML = '<i class="fas fa-times me-1"></i>Cancel All';
            globalBtn.className = 'btn btn-outline-light btn-sm bg-danger';
            this.isGlobalEdit = true;
        } else {
            this.cancelAllEdits();
        }
    }

    exitEditMode(field) {
        const displayValue = field.querySelector('.display-value');
        const editInput = field.querySelector('.edit-input');
        const editControls = field.querySelector('.edit-controls');
        const editBtn = field.querySelector('.edit-btn');

        // Switch back to display mode
        displayValue.style.display = 'block';
        editInput.style.display = 'none';
        editControls.style.display = 'none';
        editBtn.style.display = 'block';
    }


    cancelAllEdits() {
        document.querySelectorAll('.edit-field').forEach(field => {
            if (field.querySelector('.edit-input').style.display !== 'none') {
                this.cancelEdit(field);
            }
        });

        const globalBtn = document.getElementById('globalEdit');
        globalBtn.innerHTML = '<i class="fas fa-edit me-1"></i>Edit All';
        globalBtn.className = 'btn btn-outline-light btn-sm';
        this.isGlobalEdit = false;
    }

    validateField(field, value) {
        const validation = field.dataset.validation;
        const editInput = field.querySelector('.edit-input');
        const feedback = field.querySelector('.invalid-feedback');

        if (!validation) return true;

        const rules = validation.split('|');
        const errors = [];

        for (const rule of rules) {
            const [ruleName, param] = rule.split(':');

            switch (ruleName) {
                case 'required':
                    if (!value || value.trim() === '') {
                        errors.push('This field is required');
                    }
                    break;
                case 'email':
                    if (value && !/^\S+@\S+\.\S+$/.test(value)) {
                        errors.push('Please enter a valid email address');
                    }
                    break;
                case 'maxlength':
                    if (value && value.length > parseInt(param)) {
                        errors.push(`Maximum ${param} characters allowed`);
                    }
                    break;
                case 'pastdate':
                    if (value && new Date(value) > new Date()) {
                        errors.push('Birthday cannot be in the future');
                    }
                    break;
            }
        }

        if (errors.length > 0) {
            editInput.classList.add('is-invalid');
            feedback.textContent = errors[0];
            feedback.style.display = 'block';
            return false;
        } else {
            editInput.classList.remove('is-invalid');
            feedback.style.display = 'none';
            return true;
        }
    }

    showFieldError(field, message) {
        const editInput = field.querySelector('.edit-input');
        const feedback = field.querySelector('.invalid-feedback');

        editInput.classList.add('is-invalid');
        feedback.textContent = message;
        feedback.style.display = 'block';
    }

    formatDisplayValue(fieldName, value) {
        switch (fieldName) {
            case 'sex':
                return value === 'true' ? 'Male' : 'Female';
            case 'birthday':
                return value ? new Date(value).toLocaleDateString('en-US', {
                    year: 'numeric',
                    month: 'long',
                    day: 'numeric'
                }) : 'Not provided';
            case 'fullName':
                return value || 'Not provided';
            default:
                return value;
        }
    }

    showLoading(show) {
        const overlay = document.getElementById('loadingOverlay');
        overlay.style.display = show ? 'flex' : 'none';
    }

    showToast(type, message) {
        const toastId = type === 'success' ? 'successToast' : 'errorToast';
        const toast = document.getElementById(toastId);
        const toastBody = toast.querySelector('.toast-body');

        toastBody.textContent = message;

        const bsToast = new bootstrap.Toast(toast);
        bsToast.show();
    }
}
document.addEventListener('DOMContentLoaded', () => {
    new ProfileInlineEditor();
});

