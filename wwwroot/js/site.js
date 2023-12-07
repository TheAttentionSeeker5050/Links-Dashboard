// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var alertTimeout, logoutTimeout;

function resetTimer() {
    
    // make it conditional only if the alert session-logout-warning is present
    if (document.getElementById('user-is-authenticated').innerText == 'true') {
        // Clear existing timeouts
        clearTimeout(alertTimeout);
        clearTimeout(logoutTimeout);

        // Set new timeout for alert (5 seconds for testing, change to 18 minutes in production)
        alertTimeout = setTimeout(function() {
            document.getElementById('session-logout-warning').innerText = 'You will be logged out in 2 minutes';
        }, 1000*18*60); // 1080000 milliseconds = 18 minutes

        // Set new timeout for logout (10 seconds for testing, change to 20 minutes in production)
        logoutTimeout = setTimeout(function() {
            // Redirect to logout or submit a logout form
            document.getElementById('logout-form').submit();
            // or
            // window.location.href = '/logout';
        }, 1000*20*60); // 1200000 milliseconds = 20 minutes
    }
}

// Listen for any user actions
window.onload = resetTimer;
window.onmousemove = resetTimer;
window.onmousedown = resetTimer;  // Catch all mouse buttons
window.ontouchstart = resetTimer;
window.onclick = resetTimer;      // Catch touchpad clicks
window.onkeypress = resetTimer;