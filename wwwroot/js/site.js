const closeAlertButtons = document.querySelectorAll('.close-alert');

closeAlertButtons.forEach(button => {
    button.addEventListener('click', function () {
        const closestAlertDiv = this.closest('.alert');
        closestAlertDiv.style.display = 'none';
    });
});
