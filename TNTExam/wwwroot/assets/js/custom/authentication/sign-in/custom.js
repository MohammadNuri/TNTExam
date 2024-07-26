// Function to handle form submission
function kt_sign_up_submit(event) {
    // Prevent default form submission
    event.preventDefault();

    // Get the form element
    const form = document.getElementById("kt_sign_up_form");

    // Ensure the form exists
    if (!form) {
        console.error("Form not found!");
        return;
    }

    // Create a FormData object from the form
    const formData = new FormData(form);

    // Disable the submit button to prevent multiple clicks
    const submitButton = document.getElementById("kt_sign_up_submit");
    submitButton.disabled = true;

    // Send the AJAX request
    axios.post(form.action, formData)
        .then(function (response) {
            const result = response.data;

            if (result.isSuccess === true) {
                // Handle success response
                Swal.fire({
                    text: "با موفقیت وارد شدید",
                    icon: "success",
                    buttonsStyling: false,
                    confirmButtonText: "باشه فهمیدم!",
                    customClass: {
                        confirmButton: "btn btn-primary"
                    }
                }).then(function (result) {
                    if (result.isConfirmed) {
                        form.reset(); // Reset the form
                        const redirectUrl = form.getAttribute("data-kt-redirect-url");
                        if (redirectUrl) {
                            location.href = redirectUrl; // Redirect if there's a URL
                        }
                    }
                });
            } else {
                // Show error message from the server
                Swal.fire({
                    text: result.message,
                    icon: "error",
                    buttonsStyling: false,
                    confirmButtonText: "باشه فهمیدم!",
                    customClass: {
                        confirmButton: "btn btn-primary"
                    }
                });
            }
        })
        .catch(function (error) {
            // Handle unexpected errors
            Swal.fire({
                text: "متأسفیم ، به نظر می رسد برخی خطاها شناسایی شده است ، لطفاً دوباره امتحان کنید.",
                icon: "error",
                buttonsStyling: false,
                confirmButtonText: "باشه فهمیدم!",
                customClass: {
                    confirmButton: "btn btn-primary"
                }
            });
        })
        .finally(function () {
            // Re-enable the submit button
            submitButton.disabled = false;
        });
}

// Attach the function to the button click event when the DOM is fully loaded
document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("kt_sign_up_submit").addEventListener("click", kt_sign_up_submit);
});
