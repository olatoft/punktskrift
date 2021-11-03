#include <stdio.h>
#include <termios.h>


int main() {
    struct termios info;

    tcgetattr(0, &info); // Get current terminal attributes. 0 is the file descriptor for stdin

    info.c_lflag &= ~ICANON;    // Disable canonical mode
    info.c_cc[VMIN] = 0;        // Wait until at least one keystroke available
    info.c_cc[VTIME] = 0;       // No timeout

    tcsetattr(0, TCSANOW, &info); // Set immediately

    int ch;

    while ((ch = getchar()) != 27 /* Ascii Escape */ ) {
        printf("%d\n", ch);
        if (ch < 0) {
            if (ferror(stdin)) {
                printf("Tomt\n");
            }

            clearerr(stdin);
        } else {
            printf("%d\n", ch);
        }
    } 

    return 0;
}